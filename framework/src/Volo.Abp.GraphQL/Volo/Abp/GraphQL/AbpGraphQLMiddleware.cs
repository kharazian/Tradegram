using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Queries;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Volo.Abp.Users;

namespace Volo.Abp.GraphQL
{
    public class AbpGraphQLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AbpGraphQLOptions _options;
        private readonly IDocumentExecuter _executor;
        private readonly IDocumentWriter _writer;

        private static readonly JsonSerializer Serializer = new JsonSerializer();
        private static readonly MediaType JsonMediaType = new MediaType("application/json");
        private static readonly MediaType GraphQLMediaType = new MediaType("application/graphql");
        
        protected ICurrentUser CurrentUser { get; }

        public AbpGraphQLMiddleware(
            RequestDelegate next,
            AbpGraphQLOptions options,
            IDocumentExecuter executor,
            IDocumentWriter writer,
            ICurrentUser currentUser)
        {
            _next = next;
            _options = options;
            _executor = executor;
            _writer = writer;
            
            CurrentUser = currentUser;
        }

        public async Task Invoke(HttpContext context, ISchemaFactory schemaService)
        {
            if (!IsGraphQLRequest(context))
            {
                await _next(context);
            }
            else
            {
                if (CurrentUser.IsAuthenticated)
                {
                    await ExecuteAsync(context, schemaService);
                }
                else
                {
                    await context.ChallengeAsync("Api");
                }
            }
        }

        private bool IsGraphQLRequest(HttpContext context)
        {
            return context.Request.Path.StartsWithSegments(_options.Path);
        }

        private async Task ExecuteAsync(HttpContext context, ISchemaFactory schemaService)
        {
            var schema = await schemaService.GetSchema();

            AbpGraphQLRequest request = null;

            if (HttpMethods.IsPost(context.Request.Method))
            {

                var mediaType = new MediaType(context.Request.ContentType);

                try
                {
                    if (mediaType.IsSubsetOf(JsonMediaType))
                    {
                        using (var sr = new StreamReader(context.Request.Body))
                        {
                            using (var jsonTextReader = new JsonTextReader(sr))
                            {
                                request = Serializer.Deserialize<AbpGraphQLRequest>(jsonTextReader);
                            }
                        }
                    }
                    else if (mediaType.IsSubsetOf(GraphQLMediaType))
                    {
                        request = new AbpGraphQLRequest();

                        using (var sr = new StreamReader(context.Request.Body))
                        {
                            request.Query = await sr.ReadToEndAsync();
                        }
                    }
                    else if (context.Request.Query.ContainsKey("query"))
                    {
                        request = new AbpGraphQLRequest
                        {
                            Query = context.Request.Query["query"]
                        };


                        if (context.Request.Query.ContainsKey("variables"))
                        {
                            request.Variables = JObject.Parse(context.Request.Query["variables"]);
                        }

                        if (context.Request.Query.ContainsKey("operationName"))
                        {
                            request.OperationName = context.Request.Query["operationName"];
                        }
                    }
                }
                catch (Exception e)
                {
                    await WriteErrorAsync(context, "An error occured while processing the GraphQL query", e);
                    return;
                }
            }
            else if (HttpMethods.IsGet(context.Request.Method))
            {
                if (!context.Request.Query.ContainsKey("query"))
                {
                    await WriteErrorAsync(context, "The 'query' query string parameter is missing");
                    return;
                }

                request = new AbpGraphQLRequest
                {
                    Query = context.Request.Query["query"]
                };

            }

            var queryToExecute = request.Query;

            if (!string.IsNullOrEmpty(request.NamedQuery))
            {
                var namedQueries = context.RequestServices.GetServices<INamedQueryProvider>();

                var queries = namedQueries
                    .SelectMany(dict => dict.Resolve())
                    .ToDictionary(pair => pair.Key, pair => pair.Value);

                queryToExecute = queries[request.NamedQuery];
            }

            var result = await _executor.ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = queryToExecute;
                _.OperationName = request.OperationName;
                _.Inputs = request.Variables.ToInputs();
                _.UserContext = _options.BuildUserContext?.Invoke(context);

#if DEBUG
                _.ExposeExceptions = true;
#endif
            });

            var httpResult = result.Errors?.Count > 0
                ? HttpStatusCode.BadRequest
                : HttpStatusCode.OK;

            context.Response.StatusCode = (int)httpResult;
            context.Response.ContentType = "application/json";

            await _writer.WriteAsync(context.Response.Body, result);
        }

        private async Task WriteErrorAsync(HttpContext context, string message, Exception e = null)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            var errorResult = new ExecutionResult
            {
                Errors = new ExecutionErrors
                {
                    e == null ? new ExecutionError(message) : new ExecutionError(message, e)
                }
            };

            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";

            await _writer.WriteAsync(context.Response.Body, errorResult);
        }
    }
}

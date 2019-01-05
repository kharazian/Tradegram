using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.GraphQL
{
    public class AbpSchemaFactory : ISchemaFactory, IScopedDependency
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IEnumerable<ISchemaBuilder> _schemaBuilders;
        private readonly IServiceProvider _serviceProvider;

        public AbpSchemaFactory(
            IMemoryCache memoryCache,
            IEnumerable<ISchemaBuilder> schemaBuilders,
            IServiceProvider serviceProvider)
        {
            _memoryCache = memoryCache;
            _schemaBuilders = schemaBuilders;
            _serviceProvider = serviceProvider;
        }

        public Task<ISchema> GetSchema()
        {
            return _memoryCache.GetOrCreateAsync("GraphQLSchema", async f =>
            {
                f.SetSlidingExpiration(TimeSpan.FromHours(1));

                ISchema schema = new Schema
                {
                    Query = new ObjectGraphType { Name = "Query" },
                    Mutation = new ObjectGraphType { Name = "Mutation" },
                    Subscription = new ObjectGraphType { Name = "Subscription" },
                    FieldNameConverter = new AbpFieldNameConverter(),

                    DependencyResolver = _serviceProvider.GetService<IDependencyResolver>()
                };

                foreach (var builder in _schemaBuilders)
                {
                    var token = await builder.BuildAsync(schema);

                    if (token != null)
                    {
                        f.AddExpirationToken(token);
                    }
                }

                foreach (var type in _serviceProvider.GetServices<IInputObjectGraphType>())
                {
                    schema.RegisterType(type);
                }

                foreach (var type in _serviceProvider.GetServices<IObjectGraphType>())
                {
                    schema.RegisterType(type);
                }
                
                // Clean Query, Mutation and Subscription if they have no fields
                // to prevent GraphQL configuration errors.

                if (!schema.Query.Fields.Any())
                {
                    schema.Query = null;
                }

                if (!schema.Mutation.Fields.Any())
                {
                    schema.Mutation = null;
                }

                if (!schema.Subscription.Fields.Any())
                {
                    schema.Subscription = null;
                }

                schema.Initialize();

                return schema;
            });
        }
    }
}

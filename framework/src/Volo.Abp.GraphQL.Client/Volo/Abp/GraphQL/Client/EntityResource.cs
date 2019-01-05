using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Volo.Abp.DependencyInjection;
using Volo.Abp.GraphQL.Client.Extensions;

namespace Volo.Abp.GraphQL.Client
{
    public class EntityResource : ITransientDependency
    {
        private readonly HttpClient _client;

        public EntityResource(HttpClient client)
        {
            _client = client;
        }
        
        public async Task<JObject> Query(string contentType, Action<EntityTypeQueryResourceBuilder> builder)
        {
            var contentTypeBuilder = new EntityTypeQueryResourceBuilder(contentType);
            builder(contentTypeBuilder);

            var requestJson = new JObject(
                new JProperty("query", @"query { " + contentTypeBuilder.Build() + " }")
                );

            var response = await _client
                .PostJsonAsync("api/graphql", requestJson.ToString());

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            return JObject.Parse(await response.Content.ReadAsStringAsync());
        }

        public async Task<JObject> Query(string body)
        {
            var requestJson = new JObject(
                new JProperty("query", @"query { " + body + " }")
                );

            var response = await _client.PostJsonAsync("api/graphql", requestJson.ToString());

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            return JObject.Parse(await response.Content.ReadAsStringAsync());
        }

        public async Task<JObject> NamedQueryExecute(string name)
        {
            var requestJson = new JObject(
                new JProperty("namedquery", name)
                );

            var response = await _client.PostJsonAsync("api/graphql", requestJson.ToString());

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }

            return JObject.Parse(await response.Content.ReadAsStringAsync());
        }
    }
}

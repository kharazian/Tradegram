using System.Net.Http;

namespace Volo.Abp.GraphQL.Client
{
    public class AbpGraphQLClient
    {
        public AbpGraphQLClient(HttpClient client)
        {
            Client = client;
        }

        public EntityResource Content => new EntityResource(Client);

        public HttpClient Client { get; }
    }
}

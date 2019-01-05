using Newtonsoft.Json.Linq;

namespace Volo.Abp.GraphQL
{
    public class AbpGraphQLRequest
    {
        public string OperationName { get; set; }
        
        public string NamedQuery { get; set; }
        
        public string Query { get; set; }
        
        public JObject Variables { get; set; }
    }
}
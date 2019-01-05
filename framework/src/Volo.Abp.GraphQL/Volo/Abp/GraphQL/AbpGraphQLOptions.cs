using System;
using Microsoft.AspNetCore.Http;

namespace Volo.Abp.GraphQL
{
    public class AbpGraphQLOptions
    {
        public PathString Path { get; set; } = "/api/graphql";
        
        public Func<HttpContext, object> BuildUserContext { get; set; }
    }
}
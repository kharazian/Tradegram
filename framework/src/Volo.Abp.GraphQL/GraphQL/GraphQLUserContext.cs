using System;
using System.Security.Claims;

namespace GraphQL
{
    public class GraphQLUserContext
    {
        public ClaimsPrincipal User { get; set; }
        public IServiceProvider ServiceProvider { get; set; }
    }
}

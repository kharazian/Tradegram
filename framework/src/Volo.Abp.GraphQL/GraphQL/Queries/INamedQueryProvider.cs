using System.Collections.Generic;

namespace GraphQL.Queries
{
    public interface INamedQueryProvider
    {
        IDictionary<string, string> Resolve();
    }
}
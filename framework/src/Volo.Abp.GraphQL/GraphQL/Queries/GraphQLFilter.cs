using System.Collections.Generic;
using GraphQL.Types;
using Volo.Abp.DependencyInjection;
using YesSql.Core.Query;

namespace GraphQL.Queries
{
    public abstract class GraphQLFilter<TSourceType> : IGraphQLFilter<TSourceType>, ITransientDependency 
        where TSourceType : class
    {
        public virtual IQuery<TSourceType> PreQuery(IQuery<TSourceType> query, ResolveFieldContext context)
        {
            return query;
        }

        public virtual IEnumerable<TSourceType> PostQuery(IEnumerable<TSourceType> contentItems, ResolveFieldContext context)
        {
            return contentItems;
        }
    }
}

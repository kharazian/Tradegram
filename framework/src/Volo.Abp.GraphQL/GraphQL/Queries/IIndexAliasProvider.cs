using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace GraphQL.Queries
{
    public interface IIndexAliasProvider<T, TKey> 
        where T : class, IEntity<TKey>
    {
        IEnumerable<IndexAlias<T, TKey>> GetAliases();
    }
}
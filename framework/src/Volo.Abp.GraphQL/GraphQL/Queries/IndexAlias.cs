using System;
using Volo.Abp.Domain.Entities;
using YesSql.Core.Query;

namespace GraphQL.Queries
{
    public class IndexAlias<T, TKey> 
        where T : class, IEntity<TKey>
    {
        public string Alias { get; set; }

        public string Index { get; set; }

        public Func<IQuery<T>, IQuery<T>> With { get; set; }
    }
}
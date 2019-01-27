using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Tagging.Aggregates;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Tagging.Repositories
{
    public interface IProductTagRepository : IRepository<ProductTag, Guid>
    {
        Task<ProductTag> GetByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<ProductTag> FindByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<List<ProductTag>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);

        void DecreaseUsageCountOfTags(List<Guid> ids);
    }
}

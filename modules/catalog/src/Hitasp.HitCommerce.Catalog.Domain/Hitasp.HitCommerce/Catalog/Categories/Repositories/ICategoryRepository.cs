using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Categories.Repositories
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
        Task<List<Category>> GetListByParentIdAsync(Guid parentId, bool includeDetails = false,
            CancellationToken cancellationToken = default);

        Task<List<Category>> GetListRootCategory(bool includeDetails = false,
            CancellationToken cancellationToken = default);
    }
}
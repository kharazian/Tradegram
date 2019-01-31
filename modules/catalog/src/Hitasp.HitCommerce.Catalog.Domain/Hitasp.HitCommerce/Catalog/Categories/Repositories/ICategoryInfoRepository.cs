using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Categories.Repositories
{
    public interface ICategoryInfoRepository : IRepository<CategoryInfo, Guid>
    {
        
        Task<CategoryInfo> FindByNameAsync(string name, CancellationToken cancellationToken = default);

        Task<CategoryInfo> FindByTitleAsync(string title, CancellationToken cancellationToken = default);
    }
}
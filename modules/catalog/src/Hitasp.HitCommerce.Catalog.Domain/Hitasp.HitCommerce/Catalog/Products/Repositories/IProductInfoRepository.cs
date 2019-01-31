using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public interface IProductInfoRepository : IRepository<ProductInfo, Guid>
    {
        Task<ProductInfo> FindByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}
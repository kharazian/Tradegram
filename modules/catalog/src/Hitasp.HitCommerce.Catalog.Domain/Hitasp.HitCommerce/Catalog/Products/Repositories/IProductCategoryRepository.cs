using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        Task<List<ProductCategory>> GetListByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
        
        Task<List<ProductCategory>> GetListByProductIdAsync(Guid productId, CancellationToken cancellationToken = default);

        Task<ProductCategory> FindAsync(Guid productId, Guid categoryId, CancellationToken cancellationToken = default);
    }
}
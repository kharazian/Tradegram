using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public interface IProductManufacturerRepository : IRepository<ProductManufacturer>
    {
        Task<List<ProductManufacturer>> GetListByManufacturerIdAsync(Guid manufacturerId, CancellationToken cancellationToken = default);
        
        Task<List<ProductManufacturer>> GetListByProductIdAsync(Guid productId, CancellationToken cancellationToken = default);

        Task<ProductManufacturer> FindAsync(Guid productId, Guid manufacturerId, CancellationToken cancellationToken = default);
    }
}
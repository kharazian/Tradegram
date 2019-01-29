using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public class EfCoreProductManufacturerRepository : EfCoreRepository<ICatalogDbContext, ProductManufacturer>,
        IProductManufacturerRepository
    {
        public EfCoreProductManufacturerRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public async Task<List<ProductManufacturer>> GetListByManufacturerIdAsync(Guid manufacturerId, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(x => x.ManufacturerId == manufacturerId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<ProductManufacturer>> GetListByProductIdAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(x => x.ProductId == productId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<ProductManufacturer> FindAsync(Guid productId, Guid manufacturerId, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(x => x.ProductId == productId && x.ManufacturerId == manufacturerId)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }
    }
}
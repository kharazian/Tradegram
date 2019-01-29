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
    public class EfCoreProductCategoryRepository : EfCoreRepository<ICatalogDbContext, ProductCategory>,
        IProductCategoryRepository
    {
        public EfCoreProductCategoryRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<ProductCategory>> GetListByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(x => x.CategoryId == categoryId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<ProductCategory>> GetListByProductIdAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(x => x.ProductId == productId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<ProductCategory> FindAsync(Guid productId, Guid categoryId, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(x => x.ProductId == productId && x.CategoryId == categoryId)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }
    }
}
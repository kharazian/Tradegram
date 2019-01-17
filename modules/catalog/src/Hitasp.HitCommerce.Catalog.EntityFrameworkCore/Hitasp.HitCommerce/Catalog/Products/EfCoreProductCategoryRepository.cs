using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class EfCoreProductCategoryRepository : EfCoreRepository<ICatalogDbContext, ProductCategory>,
        IProductCategoryRepository
    {
        public EfCoreProductCategoryRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<ProductCategory>> GetListByCategoryId(Guid categoryId)
        {
            return await DbSet.Where(x => x.CategoryId == categoryId).ToListAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommon.Contents;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class EfCoreProductRepository : EfCoreContentBaseRepository<Product, ICatalogDbContext>,
        IProductRepository
    {
        public EfCoreProductRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<List<Product>> GetListAsync(IEnumerable<Guid> ids)
        {
            return await DbSet.Where(t => ids.Contains(t.Id)).ToListAsync();
        }
    }
}
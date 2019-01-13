using System;
using System.Linq;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class EfCoreProductTagRepository : EfCoreRepository<ICatalogDbContext, ProductTag>,
        IProductTagRepository
    {
        public EfCoreProductTagRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public void DeleteOfProduct(Guid productId)
        {
            var recordsToDelete = DbSet.Where(pt=>pt.ProductId == productId);
            DbSet.RemoveRange(recordsToDelete);
        }

        public async Task<ProductTag> FindByTagIdAndProductIdAsync(Guid productId, Guid tagId)
        {
            return await DbSet.FirstOrDefaultAsync(pt=> pt.ProductId == productId && pt.TagId == tagId);
        }
    }
}

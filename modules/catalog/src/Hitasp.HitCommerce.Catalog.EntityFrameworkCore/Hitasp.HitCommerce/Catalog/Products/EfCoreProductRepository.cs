using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommon.Contents;
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
    }
}
using Hitasp.HitCommon.Contents;
using Hitasp.HitCommon.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class EfCoreProductRepository : EfCoreContentBaseRepository<Product>, IProductRepository
    {
        public EfCoreProductRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
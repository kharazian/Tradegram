using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommon.Contents;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public class EfCoreBrandRepository : EfCoreContentBaseRepository<Brand, ICatalogDbContext>, IBrandRepository
    {
        public EfCoreBrandRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
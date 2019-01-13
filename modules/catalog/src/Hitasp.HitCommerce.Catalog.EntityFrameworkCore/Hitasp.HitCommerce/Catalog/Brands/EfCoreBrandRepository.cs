using Hitasp.HitCommerce.Catalog.Brands.Aggregates;
using Hitasp.HitCommerce.Catalog.Brands.Repositories;
using Hitasp.HitCommon.Contents;
using Hitasp.HitCommon.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public class EfCoreBrandRepository : EfCoreContentBaseRepository<Brand>, IBrandRepository
    {
        public EfCoreBrandRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
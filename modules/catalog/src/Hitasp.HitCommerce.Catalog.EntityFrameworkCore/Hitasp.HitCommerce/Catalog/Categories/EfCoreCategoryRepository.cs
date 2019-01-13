using Hitasp.HitCommon.Contents;
using Hitasp.HitCommon.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class EfCoreCategoryRepository : EfCoreContentBaseRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
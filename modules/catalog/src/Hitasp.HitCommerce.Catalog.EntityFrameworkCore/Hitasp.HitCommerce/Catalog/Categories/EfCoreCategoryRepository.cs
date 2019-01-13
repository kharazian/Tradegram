using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommon.Contents;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class EfCoreCategoryRepository : EfCoreContentBaseRepository<Category, ICatalogDbContext>, ICategoryRepository
    {
        public EfCoreCategoryRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
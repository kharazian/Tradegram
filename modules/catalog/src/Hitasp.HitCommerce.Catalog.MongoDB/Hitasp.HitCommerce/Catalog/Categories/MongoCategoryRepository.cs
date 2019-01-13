using Hitasp.HitCommon.Contents;
using Hitasp.HitCommon.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class MongoCategoryRepository : MongoContentBaseRepository<Category>, ICategoryRepository
    {
        public MongoCategoryRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
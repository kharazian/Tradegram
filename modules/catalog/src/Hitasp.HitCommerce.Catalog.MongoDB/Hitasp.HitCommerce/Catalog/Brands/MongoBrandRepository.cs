using Hitasp.HitCommon.Contents;
using Hitasp.HitCommon.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public class MongoBrandRepository : MongoContentBaseRepository<Brand>, IBrandRepository
    {
        public MongoBrandRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
using Hitasp.HitCommon.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.Media
{
    public class MongoImageRepository : MongoMediaRepository<Image>, IImageRepository
    {
        public MongoImageRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}

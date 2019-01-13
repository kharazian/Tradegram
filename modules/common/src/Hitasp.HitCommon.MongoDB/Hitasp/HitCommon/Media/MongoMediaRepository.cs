using Hitasp.HitCommon.Assets;
using Hitasp.HitCommon.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.Media
{
    public class MongoMediaRepository<TMedia> : MongoAssetBaseRepository<TMedia>, IMediaRepository<TMedia>
        where TMedia : AssetBase, IMedia
    {
        public MongoMediaRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}

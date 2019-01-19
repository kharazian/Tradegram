using Hitasp.HitCommon.Assets;
using Hitasp.HitCommon.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.Media
{
    public class MongoMediaRepository<TMedia, TContext> : MongoAssetBaseRepository<TMedia, TContext>, IMediaRepository<TMedia>
        where TMedia : Asset, IMedia
        where TContext : IAbpMongoDbContext
    {
        public MongoMediaRepository(IMongoDbContextProvider<TContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Assets;
using Hitasp.HitCommon.Media;
using Hitasp.HitCommon.MongoDB;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.Medias
{
    public class MongoMediaRepository<TMedia> : MongoDbRepository<IHitCommonMongoDbContext, TMedia, Guid>, IMediaRepository<TMedia>
        where TMedia : AssetBase, IMedia
    {
        public MongoMediaRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
        public virtual async Task<TMedia> FindByUniqueName(string uniqueName, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.UniqueName == uniqueName, GetCancellationToken(cancellationToken));
        }
    }
}

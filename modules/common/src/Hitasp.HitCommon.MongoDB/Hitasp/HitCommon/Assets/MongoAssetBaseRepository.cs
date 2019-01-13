using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Assets;
using Hitasp.HitCommon.Media;
using Hitasp.HitCommon.MongoDB;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.Assets
{
    public class MongoAssetBaseRepository<TAsset, TContext> : MongoDbRepository<TContext, TAsset, Guid>,
        IAssetBaseRepository<TAsset>
        where TAsset : AssetBase
        where TContext : IAbpMongoDbContext
    {
        public MongoAssetBaseRepository(IMongoDbContextProvider<TContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public virtual async Task<TAsset> FindByUniqueNameAsync(string uniqueName,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(x => x.UniqueName == uniqueName, GetCancellationToken(cancellationToken));
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Medias;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.MongoDB
{
    public abstract class MongoMediaRepositoryBase<TDbContext, TMedia> : MongoDbRepository<TDbContext, TMedia, Guid>,
        IMediaRepository<TMedia>
        where TDbContext : IAbpMongoDbContext
        where TMedia : Media, IMedia
    {
        protected MongoMediaRepositoryBase(IMongoDbContextProvider<TDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public virtual async Task<TMedia> FindByUniqueFileName(string uniqueFileName, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.UniqueFileName == uniqueFileName, GetCancellationToken(cancellationToken));
        }
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.MongoDB;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.Medias
{
    public class MongoMediaRepository : MongoDbRepository<IHitCommonMongoDbContext, Media, Guid>, IMediaRepository
    {
        public MongoMediaRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
        public virtual async Task<Media> FindByUniqueFileName(string uniqueFileName, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.UniqueFileName == uniqueFileName, GetCancellationToken(cancellationToken));
        }
    }
}

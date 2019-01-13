using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.MongoDB;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.Contents
{
    public class MongoContentBaseRepository<TContent> : MongoDbRepository<IHitCommonMongoDbContext, TContent, Guid>,
        IContentBaseRepository<TContent>
        where TContent : ContentBase
    {
        public MongoContentBaseRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public virtual async Task<TContent> FindByNameAsync(string name,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(x => x.Name == name, GetCancellationToken(cancellationToken));
        }
    }
}
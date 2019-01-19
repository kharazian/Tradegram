using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Contents;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.MongoDB
{
    public class MongoContentBaseRepository<TContent, TContext> : MongoDbRepository<TContext, TContent, Guid>,
        IContentBaseRepository<TContent>
        where TContent : Content
        where TContext : IAbpMongoDbContext
    {
        public MongoContentBaseRepository(IMongoDbContextProvider<TContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public virtual async Task<TContent> FindByTitleAsync(string title,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable()
                .FirstOrDefaultAsync(x => x.Title == title, GetCancellationToken(cancellationToken));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.Contents
{
    public class MongoContentOptionRepository : MongoDbRepository<IHitCommonMongoDbContext, ContentOption, Guid>,
        IContentOptionRepository
    {
        public MongoContentOptionRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }

        public async Task<List<ContentOption>> GetListAsync(string entityTypeId, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.EntityTypeId == entityTypeId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<ContentOption> FindByNameAsync(string entityTypeId, string name, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name && x.EntityTypeId == entityTypeId,
                GetCancellationToken(cancellationToken));
        }
    }
}
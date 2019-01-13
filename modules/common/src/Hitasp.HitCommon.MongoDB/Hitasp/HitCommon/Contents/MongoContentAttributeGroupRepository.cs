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
    public class MongoContentAttributeGroupRepository : MongoDbRepository<IHitCommonMongoDbContext, ContentAttributeGroup, Guid>,
        IContentAttributeGroupRepository
    {
        public MongoContentAttributeGroupRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }

        public async Task<List<ContentAttributeGroup>> GetListAsync(string entityTypeId, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.EntityTypeId == entityTypeId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<ContentAttributeGroup> FindByNameAsync(string entityTypeId, string name, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name && x.EntityTypeId == entityTypeId,
                GetCancellationToken(cancellationToken));
        }
    }
}
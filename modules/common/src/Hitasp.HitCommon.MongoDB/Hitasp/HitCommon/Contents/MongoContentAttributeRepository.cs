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
    public class MongoContentAttributeRepository : MongoDbRepository<IHitCommonMongoDbContext, ContentAttribute, Guid>,
        IContentAttributeRepository
    {
        public MongoContentAttributeRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }

        public async Task<List<ContentAttribute>> GetListAsync(Guid attributeGroupId, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.ContentAttributeGroupId == attributeGroupId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<ContentAttribute> FindByNameAsync(Guid attributeGroupId, string name, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name && x.ContentAttributeGroupId == attributeGroupId,
                GetCancellationToken(cancellationToken));
        }
    }
}
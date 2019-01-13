using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hitasp.HitCommon.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.Tagging
{
    public class MongoTagRepository : MongoDbRepository<IHitCommonMongoDbContext, Tag, Guid>, ITagRepository
    {
        public MongoTagRepository(IMongoDbContextProvider<IHitCommonMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Tag>> GetListAsync(string entityTypeId)
        {
            return await GetMongoQueryable().Where(t=>t.EntityTypeId == entityTypeId).ToListAsync();
        }

        public async Task<Tag> GetByNameAsync(string entityTypeId, string name)
        {
            return await GetMongoQueryable().Where(t => t.EntityTypeId == entityTypeId && t.Name == name).FirstAsync();
        }

        public async Task<Tag> FindByNameAsync(string entityTypeId, string name)
        {
            return await GetMongoQueryable().Where(t => t.EntityTypeId == entityTypeId && t.Name == name).FirstOrDefaultAsync();
        }

        public async Task<List<Tag>> GetListAsync(IEnumerable<Guid> ids)
        {
            return await GetMongoQueryable().Where(t => ids.Contains(t.Id)).ToListAsync();
        }

        public void DecreaseUsageCountOfTags(List<Guid> ids)
        {
            var tags = GetMongoQueryable().Where(t => ids.Contains(t.Id));

            foreach (var tag in tags)
            {
                tag.DecreaseUsageCount();
            }
        }
    }
}

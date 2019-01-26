using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Tagging.Repositories
{
    public class MongoTagRepository : MongoDbRepository<ICatalogMongoDbContext, Tag, Guid>,
        ITagRepository
    {
        public MongoTagRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Tag>> GetListAsync(Guid spaceId, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.SpaceId == spaceId).ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<Tag> GetByNameAsync(string name, Guid spaceId, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(t => t.SpaceId == spaceId && t.Name == name).FirstAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<Tag> FindByNameAsync(string name, Guid spaceId, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(t => t.SpaceId == spaceId && t.Name == name).FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Tag>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(t => ids.Contains(t.Id)).ToListAsync(GetCancellationToken(cancellationToken));
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
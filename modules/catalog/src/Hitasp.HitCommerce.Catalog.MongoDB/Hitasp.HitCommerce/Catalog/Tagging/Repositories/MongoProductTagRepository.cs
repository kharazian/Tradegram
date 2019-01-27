using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Hitasp.HitCommerce.Catalog.Tagging.Aggregates;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Tagging.Repositories
{
    public class MongoProductTagRepository : MongoDbRepository<ICatalogMongoDbContext, ProductTag, Guid>,
        IProductTagRepository
    {
        public MongoProductTagRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<ProductTag> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(t => t.Name == name).FirstAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<ProductTag> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(t => t.Name == name).FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<ProductTag>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
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
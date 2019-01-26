using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.MongoDB;
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
            throw new NotImplementedException();
        }

        public async Task<Tag> GetByNameAsync(string name, Guid spaceId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Tag> FindByNameAsync(string name, Guid spaceId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Tag>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void DecreaseUsageCountOfTags(List<Guid> ids)
        {
            throw new NotImplementedException();
        }
    }
}
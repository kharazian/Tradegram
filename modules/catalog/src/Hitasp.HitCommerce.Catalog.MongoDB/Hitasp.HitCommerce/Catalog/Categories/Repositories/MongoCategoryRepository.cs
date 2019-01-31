using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Categories.Repositories
{
    public class MongoCategoryRepository : MongoDbRepository<ICatalogMongoDbContext, Category, Guid>,
        ICategoryRepository
    {
        public MongoCategoryRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Category>> GetListByParentIdAsync(Guid parentId, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.ParentCategoryId == parentId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Category>> GetListRootCategory(bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.ParentCategoryId == null)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
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

        public async Task<List<Category>> GetListAsync(Guid spaceId, bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.SpaceId == spaceId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<Category>> GetListByParentIdAsync(Guid parentId, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.ParentCategoryId == parentId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<Category> FindByNameAsync(string name,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.CategoryInfo.Name == name,
                GetCancellationToken(cancellationToken));
        }

        public async Task<Category> FindByTitleAsync(string title,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.CategoryInfo.Title == title,
                GetCancellationToken(cancellationToken));
        }
    }
}
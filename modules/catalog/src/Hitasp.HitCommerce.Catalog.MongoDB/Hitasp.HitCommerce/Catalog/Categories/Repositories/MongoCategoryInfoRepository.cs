using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.MongoDB;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Categories.Repositories
{
    public class MongoCategoryInfoRepository : MongoDbRepository<ICatalogMongoDbContext, CategoryInfo, Guid>,
        ICategoryInfoRepository
    {
        public MongoCategoryInfoRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
        
        public async Task<CategoryInfo> FindByNameAsync(string name,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name,
                GetCancellationToken(cancellationToken));
        }

        public async Task<CategoryInfo> FindByTitleAsync(string title,
            CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Title == title,
                GetCancellationToken(cancellationToken));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public class MongoProductCategoryRepository : MongoDbRepository<ICatalogMongoDbContext, ProductCategory>,
        IProductCategoryRepository
    {
        public MongoProductCategoryRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<ProductCategory>> GetListByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.CategoryId == categoryId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<List<ProductCategory>> GetListByProductIdAsync(Guid productId, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.ProductId == productId)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<ProductCategory> FindAsync(Guid productId, Guid categoryId, CancellationToken cancellationToken = default)
        {
            return await GetMongoQueryable().Where(x => x.ProductId == productId)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }
    }
}
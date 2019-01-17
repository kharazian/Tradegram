using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class MongoProductCategoryRepository : MongoDbRepository<ICatalogMongoDbContext, ProductCategory>,
        IProductCategoryRepository
    {
        public MongoProductCategoryRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<ProductCategory>> GetListByCategoryId(Guid categoryId)
        {
            return await GetMongoQueryable().Where(x => x.CategoryId == categoryId).ToListAsync();
        }
    }
}
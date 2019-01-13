using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class MongoProductTagRepository : MongoDbRepository<ICatalogMongoDbContext, ProductTag>,
        IProductTagRepository
    {
        public MongoProductTagRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public void DeleteOfProduct(Guid productId)
        {
            var recordsToDelete = GetMongoQueryable().Where(pt => pt.ProductId == productId);
            foreach (var record in recordsToDelete)
            {
                Delete(record);
            }
        }

        public async Task<ProductTag> FindByTagIdAndProductIdAsync(Guid productId, Guid tagId)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(pt => pt.ProductId == productId && pt.TagId == tagId);
        }
    }
}

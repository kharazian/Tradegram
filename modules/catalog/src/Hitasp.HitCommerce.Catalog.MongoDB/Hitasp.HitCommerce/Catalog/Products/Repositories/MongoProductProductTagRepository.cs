using Hitasp.HitCommerce.Catalog.MongoDB;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public class MongoProductProductTagRepository : MongoDbRepository<ICatalogMongoDbContext, ProductProductTag>,
        IProductProductTagRepository
    {
        public MongoProductProductTagRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
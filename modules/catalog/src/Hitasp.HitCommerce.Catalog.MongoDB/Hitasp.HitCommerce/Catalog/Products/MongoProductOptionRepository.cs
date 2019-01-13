using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class MongoProductOptionRepository : MongoDbRepository<ICatalogMongoDbContext, ProductOption>,
        IProductOptionRepository
    {
        public MongoProductOptionRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
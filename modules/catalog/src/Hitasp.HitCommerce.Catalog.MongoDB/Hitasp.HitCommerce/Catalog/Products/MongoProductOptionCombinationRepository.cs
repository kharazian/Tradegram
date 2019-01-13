using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class MongoProductOptionCombinationRepository : MongoDbRepository<ICatalogMongoDbContext, ProductOptionCombination>,
        IProductOptionCombinationRepository
    {
        public MongoProductOptionCombinationRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
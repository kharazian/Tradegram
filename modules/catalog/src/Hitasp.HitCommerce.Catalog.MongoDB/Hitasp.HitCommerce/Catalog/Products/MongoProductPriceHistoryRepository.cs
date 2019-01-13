using System;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class MongoProductPriceHistoryRepository : MongoDbRepository<ICatalogMongoDbContext, ProductPriceHistory, Guid>, 
        IProductPriceHistoryRepository
    {
        public MongoProductPriceHistoryRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
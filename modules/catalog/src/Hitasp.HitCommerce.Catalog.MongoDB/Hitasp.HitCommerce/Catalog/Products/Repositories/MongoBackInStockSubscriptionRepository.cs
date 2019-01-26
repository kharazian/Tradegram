using System;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public class MongoBackInStockSubscriptionRepository : MongoDbRepository<ICatalogMongoDbContext, BackInStockSubscription, Guid>,
        IBackInStockSubscriptionRepository
    {
        public MongoBackInStockSubscriptionRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
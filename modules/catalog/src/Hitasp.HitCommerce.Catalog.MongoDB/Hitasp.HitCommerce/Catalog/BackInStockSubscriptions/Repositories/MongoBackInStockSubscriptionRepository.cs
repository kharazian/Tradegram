using System;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Entities;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Repositories
{
    public class MongoBackInStockSubscriptionRepository : MongoDbRepository<ICatalogMongoDbContext, BackInStockSubscription, Guid>,
        IBackInStockSubscriptionRepository
    {
        public MongoBackInStockSubscriptionRepository(IMongoDbContextProvider<ICatalogMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
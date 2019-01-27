using System;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Aggregates;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Repositories
{
    public class EfCoreBackInStockSubscriptionRepository : EfCoreRepository<ICatalogDbContext, BackInStockSubscription, Guid>,
        IBackInStockSubscriptionRepository
    {
        public EfCoreBackInStockSubscriptionRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
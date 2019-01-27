using System;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Aggregates;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Repositories
{
    public interface IBackInStockSubscriptionRepository : IRepository<BackInStockSubscription, Guid>
    {
        
    }
}
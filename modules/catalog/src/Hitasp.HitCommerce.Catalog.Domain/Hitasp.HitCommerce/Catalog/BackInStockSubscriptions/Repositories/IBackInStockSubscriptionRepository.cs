using System;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Entities;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Repositories
{
    public interface IBackInStockSubscriptionRepository : IRepository<BackInStockSubscription, Guid>
    {
        
    }
}
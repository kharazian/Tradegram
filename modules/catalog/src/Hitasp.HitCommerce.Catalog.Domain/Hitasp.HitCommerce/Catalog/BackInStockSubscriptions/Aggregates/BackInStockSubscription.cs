using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Aggregates
{
    public class BackInStockSubscription : CreationAuditedEntity<Guid>
    {
        public virtual Guid CustomerId { get; protected set; }
        public virtual Guid ProductId { get; protected set; }

        protected BackInStockSubscription()
        {
            
        }

        public BackInStockSubscription(Guid customerId, Guid productId)
        {
            CustomerId = customerId;
            ProductId = productId;
        }
    }
}
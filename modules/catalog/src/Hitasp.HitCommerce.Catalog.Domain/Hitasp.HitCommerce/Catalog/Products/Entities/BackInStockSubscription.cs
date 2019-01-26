using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class BackInStockSubscription : CreationAuditedEntity<Guid>
    {
        public virtual Guid SpaceId { get; protected set; }
        public virtual Guid CustomerId { get; protected set; }
        public virtual Guid ProductId { get; protected set; }

        protected BackInStockSubscription()
        {
            
        }

        public BackInStockSubscription(Guid spaceId, Guid customerId, Guid productId)
        {
            SpaceId = spaceId;
            CustomerId = customerId;
            ProductId = productId;
        }
    }
}
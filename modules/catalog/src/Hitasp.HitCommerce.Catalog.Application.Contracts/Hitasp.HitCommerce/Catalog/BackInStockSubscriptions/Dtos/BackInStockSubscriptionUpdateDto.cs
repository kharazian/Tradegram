using System;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Dtos
{
    public class BackInStockSubscriptionUpdateDto
    {
        public Guid ProductId { get; set; }
        
        public Guid CustomerId { get; set; }
    }
}
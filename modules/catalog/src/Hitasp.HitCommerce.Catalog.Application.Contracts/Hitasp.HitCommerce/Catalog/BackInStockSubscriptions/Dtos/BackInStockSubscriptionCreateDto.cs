using System;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Dtos
{
    public class BackInStockSubscriptionCreateDto
    {
        public Guid ProductId { get; set; }
        
        public Guid CustomerId { get; set; }
    }
}
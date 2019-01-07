using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductPriceHistory : CreationAuditedAggregateRoot<Guid>
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual decimal Price { get; protected set; }

        public virtual decimal? OldPrice { get; protected set; }

        public virtual decimal? SpecialPrice { get; protected set; }

        public virtual DateTimeOffset? SpecialPriceStart { get; protected set; }

        public virtual DateTimeOffset? SpecialPriceEnd { get; protected set; }
        

        protected ProductPriceHistory()
        {
        }

        internal ProductPriceHistory(Guid productId, decimal price)
        {
            ProductId = productId;
            Price = price;
        }

        internal void HasChangedPrice(decimal newPrice)
        {
            OldPrice = Price;
            Price = newPrice;
        }

        internal void HasSpecialPriceSet(decimal specialPrice, DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            SpecialPrice = specialPrice;
            SpecialPriceStart = startDate;
            SpecialPriceEnd = endDate;
        }
    }
}

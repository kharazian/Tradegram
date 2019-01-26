using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Mapping
{
    public class ProductDiscount : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid DiscountId { get; protected set; }

        protected ProductDiscount()
        {
        }

        internal ProductDiscount(Guid productId, Guid discountId)
        {
            ProductId = productId;
            DiscountId = discountId;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId, DiscountId};
        }
    }
}
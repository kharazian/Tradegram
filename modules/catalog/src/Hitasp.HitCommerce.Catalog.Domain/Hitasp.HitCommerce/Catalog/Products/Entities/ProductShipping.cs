using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductShipping : Entity
    {
        public Guid ProductId { get; private set; }
        public bool IsFreeShipping { get; protected set; }
        public decimal AdditionalShippingCharge { get; protected set; }
        public bool ShipSeparately { get; set; }
        public int DeliveryDateId { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }

        protected ProductShipping()
        {
        }

        public ProductShipping(Guid productId)
        {
            ProductId = productId;
        }

        public void SetAsFreeShipping(bool isFreeShipping = true, decimal additionalShippingCharge = decimal.Zero)
        {
            if (isFreeShipping)
            {
                AdditionalShippingCharge = decimal.Zero;
                IsFreeShipping = true;

                return;
            }

            if (additionalShippingCharge <= decimal.Zero)
            {
                AdditionalShippingCharge = decimal.Zero;
                IsFreeShipping = true;

                return;
            }

            IsFreeShipping = false;
            AdditionalShippingCharge = additionalShippingCharge;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId};
        }
    }
}
using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductShipping
    {
        public virtual bool IsFreeShipping { get; protected set; }
        public virtual decimal AdditionalShippingCharge { get; protected set; }
        public virtual bool ShipSeparately { get; set; }
        public virtual int DeliveryDateId { get; set; }
        public virtual decimal Weight { get; set; }
        public virtual decimal Length { get; set; }
        public virtual decimal Width { get; set; }
        public virtual decimal Height { get; set; }

        public virtual void SetShipping(bool isFreeShipping, decimal additionalShippingCharge)
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
        
        protected ProductShipping()
        {
        }

        public ProductShipping(bool isFreeShipping, decimal additionalShippingCharge)
        {
            IsFreeShipping = isFreeShipping;
            AdditionalShippingCharge = additionalShippingCharge;
        }
    }
}
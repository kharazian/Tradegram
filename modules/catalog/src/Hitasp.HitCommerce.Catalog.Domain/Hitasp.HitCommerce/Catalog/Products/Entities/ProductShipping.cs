using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductShipping : Entity
    {
        public Guid ProductId { get; private set; }
        public bool IsShipEnabled { get; protected set; }
        public bool IsFreeShipping { get; protected set; }
        public bool ShipSeparately { get; set; }
        public decimal AdditionalShippingCharge { get; protected set; }
        public int DeliveryDateId { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }

        public void SetShippingEnabled(bool isShipEnabled = true, decimal additionalShippingCharge = decimal.Zero)
        {
            if (isShipEnabled)
            {
                IsFreeShipping = true;
                IsShipEnabled = additionalShippingCharge == decimal.Zero;
                AdditionalShippingCharge = additionalShippingCharge;

                return;
            }

            IsShipEnabled = false;
            AdditionalShippingCharge = decimal.Zero;
            IsFreeShipping = true;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId};
        }
    }
}
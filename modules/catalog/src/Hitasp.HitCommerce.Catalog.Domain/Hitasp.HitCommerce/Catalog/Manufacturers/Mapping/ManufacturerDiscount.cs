using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Mapping
{
    public class ManufacturerDiscount : Entity
    {
        public virtual Guid ManufacturerId { get; protected set; }

        public virtual Guid DiscountId { get; protected set; }

        protected ManufacturerDiscount()
        {
        }

        internal ManufacturerDiscount(Guid manufacturerId, Guid discountId)
        {
            ManufacturerId = manufacturerId;
            DiscountId = discountId;
        }

        public override object[] GetKeys()
        {
            return new object[] {ManufacturerId, DiscountId};
        }
    }
}
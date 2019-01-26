using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductShippingInfo : Entity<Guid>
    {
        public virtual bool IsShipEnabled { get; set; }
        
        public virtual bool IsFreeShipping { get; set; }
        
        public virtual bool ShipSeparately { get; set; }
        
        public virtual decimal AdditionalShippingCharge { get; set; }
        
        public virtual int? DeliveryDateId { get; set; }
        
        public virtual decimal Weight { get; set; }
        
        public virtual decimal Length { get; set; }
        
        public virtual decimal Width { get; set; }
        
        public virtual decimal Height { get; set; }
        
        public virtual bool UseMultipleWarehouses { get; set; }
        
        public virtual Guid? WarehouseId { get; set; }
        
        public virtual Guid? ProductAvailabilityRangeId { get; set; }

        protected ProductShippingInfo()
        {
        }

        internal ProductShippingInfo(Guid productId) : base(productId)
        {
        }
    }
}
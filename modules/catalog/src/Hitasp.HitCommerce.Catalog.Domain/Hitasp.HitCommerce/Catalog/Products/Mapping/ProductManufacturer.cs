using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Mapping
{
    public class ProductManufacturer : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid ManufacturerId { get; protected set; }

        public virtual bool IsFeaturedProduct { get; set; }

        public virtual int DisplayOrder { get; set; }

        protected ProductManufacturer()
        {
        }

        internal ProductManufacturer(Guid productId, Guid manufacturerId)
        {
            ProductId = productId;
            ManufacturerId = manufacturerId;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId, ManufacturerId};
        }
    }
}
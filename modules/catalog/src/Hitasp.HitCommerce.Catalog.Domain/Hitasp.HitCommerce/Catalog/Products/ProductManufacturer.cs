using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductManufacturer : Entity
    {
        public virtual Guid ProductId { get; protected set; }
        
        public virtual Guid ManufacturerId { get; protected set; }
        
        public bool IsFeaturedProduct { get; set; }

        public int DisplayOrder { get; set; }

        protected ProductManufacturer()
        {
        }

        public ProductManufacturer(Guid productId, Guid manufacturerId)
        {
            ProductId = productId;
            ManufacturerId = manufacturerId;
        }

        public override object[] GetKeys()
        {
            return new object[] { ProductId, ManufacturerId};
        }
    }
}
using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductVendor : Entity
    {
        public virtual Guid ProductId { get; protected set; }
        
        public virtual Guid VendorId { get; protected set; }

        protected ProductVendor()
        {
        }

        public ProductVendor(Guid productId, Guid vendorId)
        {
            ProductId = productId;
            VendorId = vendorId;
        }


        public override object[] GetKeys()
        {
            return new object[]{ProductId, VendorId};
        }
    }
}
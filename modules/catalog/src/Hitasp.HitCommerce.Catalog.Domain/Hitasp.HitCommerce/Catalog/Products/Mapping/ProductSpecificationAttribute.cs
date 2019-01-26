using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Mapping
{
    public class ProductSpecificationAttribute : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid SpecificationAttributeOptionId { get; protected set; }

        public virtual string CustomValue { get; set; }

        public virtual bool AllowFiltering { get; set; }

        public virtual bool ShowOnProductPage { get; set; }

        public virtual int DisplayOrder { get; set; }

        public virtual SpecificationAttributeType AttributeType { get; set; }

        
        protected ProductSpecificationAttribute()
        {
        }

        internal ProductSpecificationAttribute(Guid productId, Guid specificationAttributeOptionId)
        {
            ProductId = productId;
            SpecificationAttributeOptionId = specificationAttributeOptionId;
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId, SpecificationAttributeOptionId};
        }
    }
}
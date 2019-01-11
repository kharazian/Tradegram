using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductAttribute : Entity
    {
        public virtual Guid ProductId { get; protected set; }
        
        public virtual Guid AttributeId { get; protected set; }

        public virtual string Value { get; protected set; }

        protected ProductAttribute()
        {
        }

        public ProductAttribute(Guid productId, Guid attributeId)
        {
            ProductId = productId;
            AttributeId = attributeId;
        }

        public virtual void SetValue(string value)
        {
            Check.NotNullOrWhiteSpace(value, nameof(value));
            Value = value;
        }

        public override object[] GetKeys()
        {
            return new object[]{ ProductId, AttributeId};
        }
    }
}

using System;
using System.Collections.Generic;
using Hitasp.HitCommerce.Catalog.Attributes;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductAttribute : Entity<Guid>
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid CatalogAttributeId { get; protected set; }

        public virtual string TextPrompt { get; set; }

        public virtual bool IsRequired { get; set; }

        public virtual int DisplayOrder { get; set; }

        public virtual int? ValidationMinLength { get; set; }

        public virtual int? ValidationMaxLength { get; set; }

        public virtual string ValidationFileAllowedExtensions { get; set; }

        public virtual int? ValidationFileMaximumSize { get; set; }

        public virtual string DefaultValue { get; set; }

        public virtual string ConditionAttributeXml { get; set; }

        public virtual AttributeControlType AttributeControlType { get; set; }

        public virtual ICollection<ProductAttributeValue> AttributeValues { get; protected set; }

        protected ProductAttribute()
        {
            AttributeValues = new HashSet<ProductAttributeValue>();
        }

        internal ProductAttribute(Guid id, Guid productId, Guid attributeId)
        {
            Id = id;
            ProductId = productId;
            CatalogAttributeId = attributeId;
            
            AttributeValues = new HashSet<ProductAttributeValue>();
        }
    }
}
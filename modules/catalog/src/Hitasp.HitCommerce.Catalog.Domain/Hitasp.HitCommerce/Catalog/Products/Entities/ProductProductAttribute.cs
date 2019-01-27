using System;
using System.Collections.Generic;
using Hitasp.HitCommerce.Catalog.Attributes;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductProductAttribute : Entity<Guid>
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid ProductAttributeId { get; protected set; }

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
        
        public virtual ICollection<ProductAttributeValue> ProductAttributeValues { get; protected set; }
        
        
        protected ProductProductAttribute()
        {
            ProductAttributeValues = new HashSet<ProductAttributeValue>();
        }

        internal ProductProductAttribute(Guid id, Guid productId, Guid productAttributeId)
        {
            Id = id;
            ProductId = productId;
            ProductAttributeId = productAttributeId;
            
            ProductAttributeValues = new HashSet<ProductAttributeValue>();
        }
    }
}
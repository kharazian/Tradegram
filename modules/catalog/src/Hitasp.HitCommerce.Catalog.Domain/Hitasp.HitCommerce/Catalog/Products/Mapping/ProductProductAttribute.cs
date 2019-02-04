using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Attributes;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Mapping
{
    public class ProductProductAttribute : Entity
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

        internal ProductProductAttribute(Guid productId, Guid productAttributeId)
        {
            ProductId = productId;
            ProductAttributeId = productAttributeId;

            ProductAttributeValues = new HashSet<ProductAttributeValue>();
        }

        public virtual void AddAttributeValues(Guid attributeId, [NotNull] string name)
        {
            ProductAttributeValues.Add(new ProductAttributeValue(ProductId, attributeId, name));
        }

        public virtual void RemoveAttributeValues(Guid attributeId , [NotNull] string name)
        {
            if (ProductAttributeValues.Any(x => x.ProductAttributeId == attributeId &&
                                                x.Name == name))
            {
                ProductAttributeValues.RemoveAll(x => x.ProductAttributeId == attributeId &&
                                                      x.Name == name);
            }
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId, ProductAttributeId};
        }
    }
}
using System;
using Hitasp.HitCommerce.Catalog.Attributes;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Mapping
{
    public class ProductAttributeValue : Entity
    {
        public virtual Guid ProductId { get; private set; }
        
        public virtual Guid ProductAttributeId { get; private set; }
        public virtual Guid? PictureId { get; set; }

        public virtual string Name { get; set; }

        public virtual string ColorSquaresRgb { get; set; }

        public virtual Guid? ImageSquaresPictureId { get; set; }

        public virtual decimal PriceAdjustment { get; set; }

        public virtual bool PriceAdjustmentUsePercentage { get; set; }

        public virtual decimal WeightAdjustment { get; set; }

        public virtual decimal Cost { get; set; }

        public virtual bool CustomerEntersQty { get; set; }

        public virtual int Quantity { get; set; }

        public virtual bool IsPreSelected { get; set; }

        public virtual int DisplayOrder { get; set; }
        
        public virtual int AttributeValueTypeId { get; set; }

        public virtual AttributeValueType AttributeValueType
        {
            get => (AttributeValueType) AttributeValueTypeId;
            set => AttributeValueTypeId = (int) value;
        }

        protected ProductAttributeValue()
        {
        }

        public ProductAttributeValue(Guid productId, Guid productAttributeId, [NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            ProductId = productId;
            ProductAttributeId = productAttributeId;
            Name = name;
        }

        public override object[] GetKeys()
        {
            return new object[]{ProductId, ProductAttributeId};
        }
    }
}
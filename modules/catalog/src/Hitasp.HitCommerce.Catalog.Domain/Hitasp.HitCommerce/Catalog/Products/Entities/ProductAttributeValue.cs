using System;
using Hitasp.HitCommerce.Catalog.Attributes;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductAttributeValue : Entity<Guid>
    {
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
        
        public virtual AttributeValueType AttributeValueType { get; set; }

        
        protected ProductAttributeValue()
        {
        }

        public ProductAttributeValue(Guid id, [NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Id = id;
            Name = name;
        }
    }
}
using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Attributes.Entities
{
    public class PredefinedAttributeValue : Entity<Guid>
    {
        public virtual Guid ProductAttributeId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual decimal PriceAdjustment { get; protected set; }

        public virtual bool PriceAdjustmentUsePercentage { get; protected set; }

        public virtual decimal WeightAdjustment { get; protected set; }

        public virtual decimal Cost { get; protected set; }

        public virtual bool IsPreSelected { get; protected set; }

        public virtual int DisplayOrder { get; protected set; }
        
        public virtual ProductAttribute ProductAttribute { get; protected set; }

 
        public virtual void SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (name.Length >= AttributeConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {AttributeConsts.MaxNameLength}");
            }

            Name = name;
        }

        public virtual void SetPriceAdjustment(decimal priceAdjustment, bool priceAdjustmentUsePercentage = true)
        {
            PriceAdjustment = priceAdjustment;
            PriceAdjustmentUsePercentage = priceAdjustmentUsePercentage;
        }

        public virtual void SetWeightAdjustment(decimal weightAdjustment)
        {
            WeightAdjustment = weightAdjustment;
        }

        public virtual void SetCost(decimal cost)
        {
            Cost = cost;
        }

        public virtual void SetAsPreSelected(bool isPreSelected = true)
        {
            IsPreSelected = isPreSelected;
        }

        public virtual void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }
        
        protected PredefinedAttributeValue()
        {
        }

        public PredefinedAttributeValue(Guid id, Guid productAttributeId, [NotNull] string name) : base(id)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            
            ProductAttributeId = productAttributeId;
            Name = name;
        }
    }
}
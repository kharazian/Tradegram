using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Attributes
{
    public class PredefinedAttributeValue : Entity<Guid>
    {
        public virtual Guid CatalogAttributeId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual decimal PriceAdjustment { get; protected set; }

        public virtual bool PriceAdjustmentUsePercentage { get; protected set; }

        public virtual decimal WeightAdjustment { get; protected set; }

        public virtual decimal Cost { get; protected set; }

        public virtual bool IsPreSelected { get; protected set; }

        public virtual int DisplayOrder { get; protected set; }


        protected PredefinedAttributeValue()
        {
        }

        public PredefinedAttributeValue(Guid id, Guid attributeId, [NotNull] string name) : base(id)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            
            CatalogAttributeId = attributeId;
            Name = name;
        }
        
        public void SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (name.Length >= AttributeConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {AttributeConsts.MaxNameLength}");
            }

            if (Name == name)
            {
                return;
            }

            Name = name;
        }

        public void SetPriceAdjustment(decimal priceAdjustment, bool priceAdjustmentUsePercentage = true)
        {
            PriceAdjustment = priceAdjustment;
            PriceAdjustmentUsePercentage = priceAdjustmentUsePercentage;
        }

        public void SetWeightAdjustment(decimal weightAdjustment)
        {
            WeightAdjustment = weightAdjustment;
        }

        public void SetCost(decimal cost)
        {
            Cost = cost;
        }

        public void SetAsPreSelected(bool isPreSelected = true)
        {
            IsPreSelected = isPreSelected;
        }

        public void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }
    }
}
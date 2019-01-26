using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductPriceInfo : Entity<Guid>
    {
        public virtual decimal Price { get; protected set; }

        public virtual decimal OldPrice { get; protected set; }

        public virtual decimal ProductCost { get; protected set; }

        public virtual bool CallForPrice { get; protected set; }

        public virtual bool IsAllowCustomerEntersPrice { get; protected set; }

        public virtual decimal? MinimumCustomerEnteredPrice { get; protected set; }

        public virtual decimal? MaximumCustomerEnteredPrice { get; protected set; }

        public virtual bool BasePriceEnabled { get; protected set; }

        public virtual decimal? BasePriceAmount { get; protected set; }

        public virtual int? BasePriceUnitId { get; protected set; }

        public virtual decimal? BasePriceBaseAmount { get; protected set; }

        public virtual int? BasePriceBaseUnitId { get; protected set; }

        public virtual bool IsTaxExempt { get; protected set; }

        public virtual Guid? TaxCategoryId { get; protected set; }


        protected ProductPriceInfo()
        {
        }

        internal ProductPriceInfo(Guid productId, decimal price) : base(productId)
        {
            if (price < decimal.Zero)
            {
                throw new ArgumentException($"{nameof(price)} can not be less than 0.0!");
            }

            Price = price;
        }

        public void EnableBasePrice(bool basePriceEnabled = true, decimal? basePriceAmount = null,
            int? basePriceUnitId = null,
            decimal? basePriceBaseAmount = null, int? basePriceBaseUnitId = null)
        {
            if (BasePriceEnabled == basePriceEnabled &&
                BasePriceAmount == basePriceAmount &&
                BasePriceUnitId == basePriceUnitId &&
                BasePriceBaseAmount == basePriceBaseAmount &&
                BasePriceBaseUnitId == basePriceBaseUnitId)
            {
                return;
            }

            if (basePriceEnabled)
            {
                if (basePriceUnitId == null || basePriceUnitId <= 0)
                {
                    throw new ArgumentException();
                }

                if (basePriceBaseUnitId == null || basePriceBaseUnitId <= 0)
                {
                    throw new ArgumentException();
                }

                if (basePriceAmount == null || basePriceBaseAmount == null)
                {
                    throw new ArgumentException();
                }

                BasePriceEnabled = true;
                BasePriceAmount = basePriceAmount;
                BasePriceUnitId = basePriceUnitId;
                BasePriceBaseAmount = basePriceBaseAmount;
                BasePriceBaseUnitId = basePriceBaseUnitId;
            }
            else
            {
                BasePriceEnabled = false;
                BasePriceAmount = null;
                BasePriceUnitId = null;
                BasePriceBaseAmount = null;
                BasePriceBaseUnitId = null;
            }
        }

        public void AllowCustomerEntersPrice(decimal minPrice, decimal maxPerice)
        {
            if (IsAllowCustomerEntersPrice && MinimumCustomerEnteredPrice == minPrice &&
                MaximumCustomerEnteredPrice == maxPerice)
            {
                return;
            }

            IsAllowCustomerEntersPrice = true;
            MinimumCustomerEnteredPrice = minPrice;
            MaximumCustomerEnteredPrice = maxPerice;
        }

        public void DisableCustomerEntersPrice()
        {
            if (!IsAllowCustomerEntersPrice)
            {
                return;
            }

            IsAllowCustomerEntersPrice = false;
            MinimumCustomerEnteredPrice = null;
            MaximumCustomerEnteredPrice = null;
        }

        public void SetProductCost(decimal productCost)
        {
            if (ProductCost == productCost)
            {
                return;
            }

            ProductCost = productCost;
        }

        public void ChangePrice(decimal newPrice)
        {
            if (newPrice < decimal.Zero)
            {
                throw new ArgumentException($"{nameof(newPrice)} can not be less than 0.0!");
            }

            if (Price == newPrice)
            {
                return;
            }

            OldPrice = Price;
            Price = newPrice;
        }

        public void SetAsCallForPrice(bool callForPrice = true)
        {
            if (CallForPrice == callForPrice)
            {
                return;
            }

            if (callForPrice && Price > 0)
            {
                ChangePrice(decimal.One);

                return;
            }

            CallForPrice = callForPrice;
        }
        
        public void SetAsTaxExempt(bool isTaxExempt = true, Guid? taxCategoryId = null)
        {
            if (IsTaxExempt == isTaxExempt && TaxCategoryId == taxCategoryId)
            {
                return;
            }

            if (isTaxExempt)
            {
                TaxCategoryId = null;
                IsTaxExempt = true;

                return;
            }

            if (taxCategoryId == null || taxCategoryId == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(taxCategoryId)} must be a valid identity");
            }

            TaxCategoryId = taxCategoryId;
            IsTaxExempt = false;
        }
    }
}
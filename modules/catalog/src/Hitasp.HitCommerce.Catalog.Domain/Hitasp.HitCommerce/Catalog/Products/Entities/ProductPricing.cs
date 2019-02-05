using System;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductPricing
    {
        #region General

        public virtual decimal Price { get; protected set; }
        public virtual decimal OldPrice { get; protected set; }

        internal void SetPrice(decimal newPrice)
        {
            OldPrice = Price;

            Price = newPrice;
        }

        public virtual decimal ProductCost { get; protected set; }
        public virtual bool DisableBuyButton { get; set; }
        public virtual bool DisableWishListButton { get; set; }
        public virtual bool CallForPrice { get; set; }

        public virtual void SetProductCost(decimal productCost)
        {
            if (productCost <= decimal.Zero)
            {
                ProductCost = decimal.Zero;

                return;
            }

            ProductCost = productCost;
        }

        #endregion

        #region PreOrder

        public virtual bool AvailableForPreOrder { get; protected set; }
        public virtual DateTime? PreOrderAvailabilityStartDate { get; protected set; }

        public virtual void SetAsAvailableForPreOrder(bool availableForPreOrder = true,
            DateTime? preOrderAvailabilityStartDate = null)
        {
            if (preOrderAvailabilityStartDate.HasValue && preOrderAvailabilityStartDate < DateTime.Now)
            {
                preOrderAvailabilityStartDate = DateTime.Now;
            }

            AvailableForPreOrder = availableForPreOrder;
            PreOrderAvailabilityStartDate = preOrderAvailabilityStartDate;
        }

        #endregion

        //Uses only in seller bot
        #region Custom Price
        
        public virtual bool CustomerEntersPrice { get; protected set; }
        public virtual decimal MinimumCustomerEnteredPrice { get; protected set; }
        public virtual decimal MaximumCustomerEnteredPrice { get; protected set; }

        public virtual void AllowCustomerEntersPrice(bool allow, decimal? minPrice = null, decimal? maxPerice = null)
        {
            if (allow)
            {
                if (!minPrice.HasValue || !maxPerice.HasValue)
                {
                    CustomerEntersPrice = false;

                    return;
                }

                if (minPrice <= decimal.Zero || minPrice >= maxPerice)
                {
                    CustomerEntersPrice = false;

                    return;
                }

                CustomerEntersPrice = true;
                MinimumCustomerEnteredPrice = minPrice.Value;
                MaximumCustomerEnteredPrice = maxPerice.Value;

                return;
            }

            CustomerEntersPrice = false;
            MinimumCustomerEnteredPrice = decimal.Zero;
            MaximumCustomerEnteredPrice = decimal.Zero;
        }

        #endregion

        #region Periodable

        public virtual bool IsRental { get; protected set; }
        public virtual int RentalPriceLength { get; protected set; }
        public virtual int RentalPricePeriodId { get; protected set; }

        public virtual RentalPricePeriod RentalPricePeriod
        {
            get => (RentalPricePeriod) RentalPricePeriodId;
            set => RentalPricePeriodId = (int) value;
        }
        
        public virtual void SetAsRental(int rentalPriceLength, int rentalPricePeriodId)
        {
            if (rentalPriceLength <= 0)
            {
                throw new ArgumentException($"{nameof(rentalPriceLength)} is not valid!");
            }

            RentalPriceLength = rentalPriceLength;
            RentalPricePeriodId = rentalPricePeriodId;
            IsRecurring = false;
            IsRental = true;
        }
        
        public virtual bool IsRecurring { get; protected set; }
        public virtual int RecurringCycleLength { get; protected set; }
        public virtual int RecurringCyclePeriodId { get; protected set; }
        public virtual int RecurringTotalCycles { get; protected set; }
        public virtual RecurringProductCyclePeriod RecurringCyclePeriod
        {
            get => (RecurringProductCyclePeriod) RecurringCyclePeriodId;
            protected set => RecurringCyclePeriodId = (int) value;
        }

        public virtual void SetAsRecurring(int recurringCycleLength, int recurringTotalCycles,
            int recurringCyclePeriodId)
        {
            if (recurringCycleLength <= 0)
            {
                throw new ArgumentException($"{nameof(recurringCycleLength)} is not valid!");
            }

            if (recurringTotalCycles <= 0)
            {
                throw new ArgumentException($"{nameof(recurringTotalCycles)} is not valid!");
            }

            RecurringCycleLength = recurringCycleLength;
            RecurringTotalCycles = recurringTotalCycles;
            RecurringCyclePeriodId = recurringCyclePeriodId;
            IsRental = false;
            IsRecurring = true;
        }

        public virtual void SetAsForcePay()
        {
            IsRental = false;
            RentalPriceLength = 0;
            IsRecurring = false;
            RecurringCycleLength = 0;
            RecurringTotalCycles = 0;
        }

        #endregion

        #region Tax

        public virtual bool IsTaxExempt { get; protected set; }
        public virtual Guid? TaxCategoryId { get; protected set; }

        public virtual void SetAsTaxExempt(bool isTaxExempt = true, Guid? taxCategoryId = null)
        {
            if (isTaxExempt)
            {
                TaxCategoryId = null;
                IsTaxExempt = true;

                return;
            }

            if (taxCategoryId == null || taxCategoryId == Guid.Empty)
            {
                TaxCategoryId = null;
                IsTaxExempt = true;

                return;
            }

            TaxCategoryId = taxCategoryId;
            IsTaxExempt = false;
        }

        #endregion

        #region Ctor

        protected ProductPricing()
        {
        }

        public ProductPricing(decimal price)
        {
            if (price < decimal.Zero)
            {
                throw new ArgumentException($"{nameof(price)} can not be less than 0.0!");
            }
            
            SetPrice(price);
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductPricing : Entity
    {
        #region General

        public Guid ProductId { get; private set; }
        public decimal Price { get; protected set; }
        public decimal OldPrice { get; protected set; }

        internal void SetPrice(decimal newPrice)
        {
            OldPrice = Price;

            Price = newPrice;
        }

        public decimal ProductCost { get; protected set; }
        public bool DisableBuyButton { get; set; }
        public bool DisableWishListButton { get; set; }
        public bool CallForPrice { get; set; }

        public void SetProductCost(decimal productCost)
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

        public bool AvailableForPreOrder { get; protected set; }
        public DateTime? PreOrderAvailabilityStartDate { get; protected set; }

        public void SetAsAvailableForPreOrder(bool availableForPreOrder = true,
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
        
        public bool CustomerEntersPrice { get; protected set; }
        public decimal MinimumCustomerEnteredPrice { get; protected set; }
        public decimal MaximumCustomerEnteredPrice { get; protected set; }

        public void AllowCustomerEntersPrice(bool allow, decimal? minPrice = null, decimal? maxPerice = null)
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

        public bool IsRental { get; protected set; }
        public int RentalPriceLength { get; protected set; }
        public int RentalPricePeriodId { get; protected set; }

        public RentalPricePeriod RentalPricePeriod
        {
            get => (RentalPricePeriod) RentalPricePeriodId;
            set => RentalPricePeriodId = (int) value;
        }
        
        public void SetAsRental(int rentalPriceLength, int rentalPricePeriodId)
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
        
        public bool IsRecurring { get; protected set; }
        public int RecurringCycleLength { get; protected set; }
        public int RecurringCyclePeriodId { get; protected set; }
        public int RecurringTotalCycles { get; protected set; }
        public RecurringProductCyclePeriod RecurringCyclePeriod
        {
            get => (RecurringProductCyclePeriod) RecurringCyclePeriodId;
            protected set => RecurringCyclePeriodId = (int) value;
        }

        public void SetAsRecurring(int recurringCycleLength, int recurringTotalCycles,
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

        public void SetAsForcePay()
        {
            IsRental = false;
            RentalPriceLength = 0;
            IsRecurring = false;
            RecurringCycleLength = 0;
            RecurringTotalCycles = 0;
        }

        #endregion

        #region Discounts

        public bool HasDiscountsApplied { get; protected set; }

        public ICollection<ProductDiscount> ProductDiscounts { get; protected set; }

        public void AddDiscount(Guid discountId)
        {
            ProductDiscounts.Add(new ProductDiscount(ProductId, discountId));
            HasDiscountsApplied = true;
        }

        public void RemoveDiscount(Guid discountId)
        {
            if (ProductDiscounts.Any(x => x.DiscountId == discountId))
                ProductDiscounts.RemoveAll(x => x.DiscountId == discountId);

            if (!ProductDiscounts.Any())
            {
                HasDiscountsApplied = false;
            }
        }

        #endregion

        #region Tax

        public bool IsTaxExempt { get; protected set; }
        public Guid? TaxCategoryId { get; protected set; }

        public void SetAsTaxExempt(bool isTaxExempt = true, Guid? taxCategoryId = null)
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

        protected ProductPricing()
        {
            ProductDiscounts = new HashSet<ProductDiscount>();
        }

        public ProductPricing(Guid productId, decimal price)
        {
            if (price < decimal.Zero)
            {
                throw new ArgumentException($"{nameof(price)} can not be less than 0.0!");
            }
            
            ProductId = productId;
            SetPrice(price);
        }

        public override object[] GetKeys()
        {
            return new object[] {ProductId};
        }
    }
}
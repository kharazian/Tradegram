using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductOrderingInfo : Entity<Guid>
    {
        public virtual string AllowedQuantities { get; protected set; }

        public virtual int OrderMinimumQuantity { get; protected set; }

        public virtual int OrderMaximumQuantity { get; protected set; }

        public virtual bool AvailableForPreOrder { get; protected set; }

        public virtual DateTime? PreOrderAvailabilityStartDate { get; protected set; }

        public virtual bool IsBuyButtonDisabled { get; protected set; }

        public virtual bool IsWishListButtonDisabled { get; protected set; }

        public virtual bool NotReturnable { get; protected set; }

        public virtual bool IsRecurring { get; protected set; }

        public virtual int RecurringCycleLength { get; protected set; }

        public virtual int RecurringTotalCycles { get; protected set; }

        public virtual RecurringProductCyclePeriod RecurringCyclePeriod { get; protected set; }

        public virtual bool IsRental { get; protected set; }

        public virtual int RentalPriceLength { get; protected set; }

        public virtual RentalPricePeriod RentalPricePeriod { get; protected set; }


        protected ProductOrderingInfo()
        {
        }

        internal ProductOrderingInfo(Guid productId) : base(productId)
        {
        }


        public void DisableBuyButton(bool isBuyButtonDisabled = false)
        {
            if (IsBuyButtonDisabled == isBuyButtonDisabled)
            {
                return;
            }

            IsBuyButtonDisabled = isBuyButtonDisabled;
        }

        public void SetAllowedQuantities(IEnumerable<int> allowedQuantities)
        {
            allowedQuantities = allowedQuantities.Distinct().ToArray();

            if (allowedQuantities.Any(x => x <= 0))
            {
                throw new ArgumentException($"{nameof(allowedQuantities)} can not be have value less than one!");
            }

            if (!string.IsNullOrWhiteSpace(AllowedQuantities))
            {
                AllowedQuantities = "";
            }

            AllowedQuantities = string.Join(",", allowedQuantities);
        }

        public void DisableWishListButton(bool isWishListButtonDisabled = false)
        {
            if (IsWishListButtonDisabled == isWishListButtonDisabled)
            {
                return;
            }

            IsWishListButtonDisabled = isWishListButtonDisabled;
        }

        public void SetOrderQuantityLimitation(int orderMinimumQuantity, int orderMaximumQuantity)
        {
            if (orderMinimumQuantity <= 0 ||
                orderMaximumQuantity <= 0 ||
                orderMaximumQuantity <= orderMinimumQuantity)
            {
                throw new ArgumentException();
            }

            if (OrderMinimumQuantity == orderMinimumQuantity &&
                OrderMaximumQuantity == orderMaximumQuantity)
            {
                return;
            }

            OrderMinimumQuantity = orderMinimumQuantity;
            OrderMaximumQuantity = orderMaximumQuantity;
        }

        public void SetAsAvailableForPreOrder(bool availableForPreOrder = true,
            DateTime? preOrderAvailabilityStartDate = null)
        {
            if (preOrderAvailabilityStartDate.HasValue && preOrderAvailabilityStartDate < DateTime.Now)
            {
                throw new ArgumentException();
            }

            if (AvailableForPreOrder == availableForPreOrder &&
                PreOrderAvailabilityStartDate == preOrderAvailabilityStartDate)
            {
                return;
            }

            AvailableForPreOrder = availableForPreOrder;
            PreOrderAvailabilityStartDate = preOrderAvailabilityStartDate;
        }

        public void SetAsNotReturnable(bool notReturnable = true)
        {
            if (NotReturnable == notReturnable)
            {
                return;
            }

            NotReturnable = notReturnable;
        }

        public void SetAsRecurring(int recurringCycleLength, int recurringTotalCycles,
            RecurringProductCyclePeriod recurringCyclePeriod)
        {
            if (recurringCycleLength <= 0)
            {
                throw new ArgumentException();
            }

            if (recurringTotalCycles <= 0)
            {
                throw new ArgumentException();
            }

            if (RecurringCycleLength == recurringCycleLength &&
                RecurringTotalCycles == recurringTotalCycles &&
                RecurringCyclePeriod == recurringCyclePeriod)
            {
                return;
            }

            RecurringCycleLength = recurringCycleLength;
            RecurringTotalCycles = recurringTotalCycles;
            RecurringCyclePeriod = recurringCyclePeriod;

            IsRental = false;
            IsRecurring = true;
        }

        public void SetAsRental(int rentalPriceLength, RentalPricePeriod rentalPricePeriod)
        {
            if (rentalPriceLength <= 0)
            {
                throw new ArgumentException();
            }

            if (RentalPriceLength == rentalPriceLength &&
                RentalPricePeriod == rentalPricePeriod)
            {
                return;
            }

            RentalPriceLength = rentalPriceLength;
            RentalPricePeriod = rentalPricePeriod;

            IsRental = true;
            IsRecurring = false;
        }
    }
}
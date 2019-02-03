using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Products.Etos;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductPricing : Entity
    {
        public Guid ProductId { get; private set; }
        public decimal Price { get; protected set; }

        public decimal OldPrice { get; protected set; }

        public void ChangePrice(decimal newPrice)
        {
            if (newPrice < decimal.Zero)
            {
                throw new ArgumentException($"{nameof(newPrice)} can not be less than 0.0!");
            }

            ChangePriceInternal(newPrice);
        }

        private void ChangePriceInternal(decimal newPrice, bool triggerEvent = true)
        {
            if (Price == newPrice)
            {
                return;
            }

            //sample distributed event
            if (triggerEvent)
            {
                AddDistributedEvent(new ProductPriceChangedEto(Price, newPrice));
            }

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

        public bool BasePriceEnabled { get; protected set; }
        public decimal BasePriceAmount { get; protected set; }
        public int BasePriceUnitId { get; protected set; }
        public decimal BasePriceBaseAmount { get; protected set; }
        public int BasePriceBaseUnitId { get; protected set; }

        public void EnableBasePrice(bool basePriceEnabled, decimal basePriceAmount = decimal.Zero,
            int basePriceUnitId = 0,
            decimal basePriceBaseAmount = decimal.Zero, int basePriceBaseUnitId = 0)
        {
            if (basePriceEnabled)
            {
                if (basePriceUnitId <= 0 || basePriceBaseUnitId <= 0)
                {
                    BasePriceEnabled = false;

                    return;
                }

                if (basePriceAmount <= decimal.Zero || basePriceBaseAmount <= decimal.Zero)
                {
                    BasePriceEnabled = false;

                    return;
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
                BasePriceAmount = decimal.Zero;
                BasePriceUnitId = 0;
                BasePriceBaseAmount = decimal.Zero;
                BasePriceBaseUnitId = 0;
            }
        }

        public bool HasDiscountsApplied { get; protected set; }

        public ICollection<ProductDiscount> ProductDiscounts { get; protected set; }

        public void AddDiscount(Guid discountId)
        {
            ProductDiscounts.Add(new ProductDiscount(Id, discountId));
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

        public override object[] GetKeys()
        {
            return new object[]{ProductId};
        }
    }
}
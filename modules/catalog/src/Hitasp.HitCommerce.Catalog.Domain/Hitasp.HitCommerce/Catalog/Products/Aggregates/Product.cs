using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Exceptions;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public abstract class Product : FullAuditedAggregateRoot<Guid>
    {
        public string ProductType { get; protected set; }

        public Guid ProductTemplateId { get; protected set; }

        public Guid? PictureId { get; protected set; }

        public string Code { get; protected set; }

        public string Name { get; protected set; }

        public string Title { get; protected set; }

        public string ShortDescription { get; protected set; }

        public string Description { get; protected set; }

        public string MetaTitle { get; protected set; }

        public string MetaKeywords { get; protected set; }

        public string MetaDescription { get; protected set; }

        public decimal Price { get; protected set; }

        public decimal OldPrice { get; protected set; }

        public decimal ProductCost { get; protected set; }

        public bool CallForPrice { get; protected set; }

        public bool IsAllowCustomerEntersPrice { get; protected set; }

        public decimal? MinimumCustomerEnteredPrice { get; protected set; }

        public decimal? MaximumCustomerEnteredPrice { get; protected set; }

        public bool BasePriceEnabled { get; protected set; }

        public decimal? BasePriceAmount { get; protected set; }

        public int? BasePriceUnitId { get; protected set; }

        public decimal? BasePriceBaseAmount { get; protected set; }

        public int? BasePriceBaseUnitId { get; protected set; }

        public bool IsTaxExempt { get; protected set; }

        public Guid? TaxCategoryId { get; protected set; }

        public bool IsNew { get; protected set; }

        public bool IsPublished { get; protected set; }

        public DateTime? MarkAsNewStartDate { get; protected set; }

        public DateTime? MarkAsNewEndDate { get; protected set; }

        public DateTime? AvailableStartDate { get; protected set; }

        public DateTime? AvailableEndDate { get; protected set; }

        public bool ShowOnHomePage { get; protected set; }

        public bool VisibleIndividually { get; protected set; }

        public int DisplayOrder { get; protected set; }

        public string AllowedQuantities { get; protected set; }

        public int OrderMinimumQuantity { get; protected set; }

        public int OrderMaximumQuantity { get; protected set; }

        public bool AvailableForPreOrder { get; protected set; }

        public DateTime? PreOrderAvailabilityStartDate { get; protected set; }

        public bool IsBuyButtonDisabled { get; protected set; }

        public bool IsWishListButtonDisabled { get; protected set; }

        public bool NotReturnable { get; protected set; }

        public bool IsRecurring { get; protected set; }

        public int RecurringCycleLength { get; protected set; }

        public int RecurringTotalCycles { get; protected set; }

        public RecurringProductCyclePeriod RecurringCyclePeriod { get; protected set; }

        public bool IsRental { get; protected set; }

        public int RentalPriceLength { get; protected set; }

        public RentalPricePeriod RentalPricePeriod { get; protected set; }

        public double RatingAverage { get; protected set; }

        public int RatingCount { get; protected set; }

        public bool IsShipEnabled { get; set; }

        public bool IsFreeShipping { get; set; }

        public bool ShipSeparately { get; set; }

        public decimal AdditionalShippingCharge { get; set; }

        public int? DeliveryDateId { get; set; }

        public decimal Weight { get; set; }

        public decimal Length { get; set; }

        public decimal Width { get; set; }

        public decimal Height { get; set; }

        public bool UseMultipleWarehouses { get; set; }

        public Guid? WarehouseId { get; set; }

        public Guid? ProductAvailabilityRangeId { get; set; }
        
        public bool HasUserAgreement { get; protected set; }

        public string UserAgreementText { get; protected set; }

        public ICollection<ProductCategory> ProductCategories { get; protected set; }

        public ICollection<ProductManufacturer> ProductManufacturers { get; protected set; }

        public ICollection<ProductPicture> ProductPictures { get; protected set; }

        public ICollection<ProductProductTag> ProductTags { get; protected set; }

        public ICollection<ProductDiscount> ProductDiscounts { get; protected set; }

        public ICollection<ProductProductAttribute> ProductAttributes { get; protected set; }

        public ICollection<CrossSellProduct> CrossSellProducts { get; protected set; }

        public ICollection<RelatedProduct> RelatedProducts { get; protected set; }

        public ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes { get; protected set; }

        public ICollection<ProductAttributeCombination> AttributeCombinations { get; protected set; }


        public void SetProductTemplate(Guid productTemplateId)
        {
            if (productTemplateId == Guid.Empty)
            {
                throw new InvalidIdentityException(nameof(productTemplateId));
            }

            if (ProductTemplateId == productTemplateId)
            {
                return;
            }

            ProductTemplateId = productTemplateId;
        }

        public void SetPictureId(Guid? pictureId)
        {
            if (pictureId == Guid.Empty || pictureId == null)
            {
                PictureId = null;
            }

            if (PictureId == pictureId)
            {
                return;
            }

            PictureId = pictureId;
        }

        public void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (Name == name)
            {
                return;
            }

            if (name.Length >= ProductConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {ProductConsts.MaxNameLength}");
            }

            Name = name;
        }

        public void SetTitle([NotNull] string title)
        {
            Check.NotNullOrWhiteSpace(title, nameof(title));

            if (Title == title)
            {
                return;
            }

            if (title.Length >= ProductConsts.MaxTitleLength)
            {
                throw new ArgumentException($"Title can not be longer than {ProductConsts.MaxTitleLength}");
            }

            Title = title;
        }

        public void SetDescription(string description)
        {
            if (Description == description)
            {
                return;
            }

            if (description.Length >= ProductConsts.MaxDescriptionLength)
            {
                throw new ArgumentException(
                    $"Description can not be longer than {ProductConsts.MaxDescriptionLength}");
            }

            Description = description;
        }

        public void SetShortDescription([NotNull] string shortDescription)
        {
            Check.NotNullOrWhiteSpace(shortDescription, nameof(shortDescription));

            if (ShortDescription == shortDescription)
            {
                return;
            }

            if (shortDescription.Length >= ProductConsts.MaxShortDescriptionLength)
            {
                throw new ArgumentException(
                    $"Short description can not be longer than {ProductConsts.MaxShortDescriptionLength}");
            }

            ShortDescription = shortDescription;
        }

        public void SetMetaData(string metaTitle, string metaKeywords, string metaDescription)
        {
            if (MetaTitle == metaTitle &&
                MetaKeywords == metaKeywords &&
                MetaDescription == metaDescription)
            {
                return;
            }

            if (metaTitle.Length >= ProductConsts.MaxMetaTitleLength)
            {
                throw new ArgumentException($"Meta Title can not be longer than {ProductConsts.MaxMetaTitleLength}");
            }

            if (metaKeywords.Length >= ProductConsts.MaxMetaKeywordsLength)
            {
                throw new ArgumentException(
                    $"Meta Keywords can not be longer than {ProductConsts.MaxMetaKeywordsLength}");
            }

            if (metaDescription.Length >= ProductConsts.MaxMetaDescriptionLength)
            {
                throw new ArgumentException(
                    $"Meta Description can not be longer than {ProductConsts.MaxMetaDescriptionLength}");
            }

            MetaTitle = metaTitle;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
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
                    throw new ArgumentException($"{nameof(basePriceUnitId)} is not valid");
                }

                if (basePriceBaseUnitId == null || basePriceBaseUnitId <= 0)
                {
                    throw new ArgumentException($"{nameof(basePriceBaseUnitId)} is not valid");
                }

                if (basePriceAmount == null || basePriceAmount <= decimal.Zero)
                {
                    throw new ArgumentException($"{nameof(basePriceAmount)} is not valid");
                }

                if (basePriceBaseAmount == null || basePriceBaseAmount <= decimal.Zero)
                {
                    throw new ArgumentException($"{nameof(basePriceBaseAmount)} is not valid");
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

        public void AllowCustomerEntersPrice(bool allow = false, decimal? minPrice = null, decimal? maxPerice = null)
        {
            if (allow)
            {
                if (minPrice <= decimal.Zero || minPrice >= maxPerice)
                {
                    throw new ArgumentException($"{nameof(minPrice)} is not valid");
                }

                if (IsAllowCustomerEntersPrice &&
                    MinimumCustomerEnteredPrice == minPrice &&
                    MaximumCustomerEnteredPrice == maxPerice)
                {
                    return;
                }

                IsAllowCustomerEntersPrice = true;
                MinimumCustomerEnteredPrice = minPrice;
                MaximumCustomerEnteredPrice = maxPerice;
            }

            IsAllowCustomerEntersPrice = false;
            MinimumCustomerEnteredPrice = null;
            MaximumCustomerEnteredPrice = null;
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

        public void SetAsHomePageItem(bool showOnHomePage = true)
        {
            if (ShowOnHomePage == showOnHomePage)
            {
                return;
            }

            ShowOnHomePage = showOnHomePage;
        }

        public void DisplayIndividually(bool visibleIndividually = true)
        {
            if (VisibleIndividually == visibleIndividually)
            {
                return;
            }

            VisibleIndividually = visibleIndividually;
        }

        public void MarkAsNew(DateTime? startDate, DateTime? endDate)
        {
            if (IsNew && MarkAsNewStartDate == startDate && MarkAsNewEndDate == endDate)
            {
                return;
            }

            if (startDate.HasValue && startDate < DateTime.Now)
            {
                throw new ArgumentException("Can not set start date in the past!",
                    nameof(startDate));
            }

            if (endDate.HasValue && endDate <= startDate)
            {
                throw new ArgumentException("Can not set end date in the past of start date!",
                    nameof(endDate));
            }

            IsNew = true;
            MarkAsNewStartDate = startDate;
            MarkAsNewEndDate = endDate;
        }

        public void RemoveNewMarker()
        {
            IsNew = false;
            MarkAsNewStartDate = null;
            MarkAsNewEndDate = null;
        }

        public void SetPublishDate(DateTime startDate,
            DateTime? endDate)
        {
            if (IsPublished && AvailableStartDate == startDate && AvailableEndDate == endDate)
            {
                return;
            }

            if (startDate < DateTime.Now)
            {
                throw new ArgumentException("Can not set start date in the past!",
                    nameof(startDate));
            }

            if (endDate.HasValue && endDate <= startDate)
            {
                throw new ArgumentException("Can not set end date in the past of start date!",
                    nameof(endDate));
            }

            if (startDate <= DateTime.Now)
            {
                SetAsPublished();
            }
            else
            {
                SetAsPublished(false);
            }

            AvailableStartDate = startDate;
            AvailableEndDate = endDate;
        }

        private void SetAsPublished(bool publish = true)
        {
            if (IsPublished == publish)
            {
                return;
            }

            IsPublished = publish;
        }

        public void SetDisplayOrder(int displayOrder)
        {
            if (displayOrder < 0)
            {
                throw new ArgumentException($"{nameof(displayOrder)} can not be less than zero!");
            }

            if (DisplayOrder == displayOrder)
            {
                return;
            }

            DisplayOrder = displayOrder;
        }

        public void UpdateRatingAverage(double newRate)
        {
            var average = (RatingAverage * RatingCount + newRate) / (RatingCount + 1);
            RatingAverage = Math.Round(average * 2, MidpointRounding.AwayFromZero) / 2;

            IncreaseRatingCount();
        }

        private void IncreaseRatingCount()
        {
            RatingCount++;
        }

        
        public void SetUserAgreementText(bool hasUserAgreement, string userAgreementText = "")
        {
            if (string.IsNullOrWhiteSpace(userAgreementText))
            {
                HasUserAgreement = false;

                return;
            }

            if (HasUserAgreement == hasUserAgreement && UserAgreementText == userAgreementText)
            {
                return;
            }

            UserAgreementText = userAgreementText;
            HasUserAgreement = hasUserAgreement;
        }
        
        public void AddCategory(Guid categoryId)
        {
            ProductCategories.Add(new ProductCategory(Id, categoryId));
        }

        public void RemoveCategory(Guid categoryId)
        {
            if (ProductCategories == null)
            {
                throw new ReferenceNotLoadedException(nameof(ProductCategories));
            }

            if (ProductCategories.Any(x => x.CategoryId == categoryId))
            {
                ProductCategories.RemoveAll(x => x.CategoryId == categoryId);
            }
        }

        public void AddManufacturer(Guid manufacturerId)
        {
            ProductManufacturers.Add(new ProductManufacturer(Id, manufacturerId));
        }

        public void RemoveManufacturer(Guid manufacturerId)
        {
            if (ProductManufacturers == null)
            {
                throw new ReferenceNotLoadedException(nameof(ProductManufacturers));
            }

            if (ProductManufacturers.Any(x => x.ManufacturerId == manufacturerId))
            {
                ProductManufacturers.RemoveAll(x => x.ManufacturerId == manufacturerId);
            }
        }

        public void AddPicture(Guid pictureId)
        {
            ProductPictures.Add(new ProductPicture(Id, pictureId));
        }

        public void RemovePicture(Guid pictureId)
        {
            if (ProductPictures == null)
            {
                throw new ReferenceNotLoadedException(nameof(ProductPictures));
            }

            if (ProductPictures.Any(x => x.PictureId == pictureId))
            {
                ProductPictures.RemoveAll(x => x.PictureId == pictureId);
            }
        }

        public void AddSpecificationAttribute(Guid specificationAttributeOptionId)
        {
            ProductSpecificationAttributes.Add(
                new ProductSpecificationAttribute(Id, specificationAttributeOptionId));
        }

        public void RemoveSpecificationAttribute(Guid specificationAttributeOptionId)
        {
            if (ProductSpecificationAttributes == null)
            {
                throw new ReferenceNotLoadedException(nameof(ProductSpecificationAttributes));
            }

            if (ProductSpecificationAttributes.Any(x =>
                x.SpecificationAttributeOptionId == specificationAttributeOptionId))
            {
                ProductSpecificationAttributes.RemoveAll(x =>
                    x.SpecificationAttributeOptionId == specificationAttributeOptionId);
            }
        }

        public void AddTag(Guid tagId)
        {
            ProductTags.Add(new ProductProductTag(Id, tagId));
        }

        public void RemoveTag(Guid tagId)
        {
            if (ProductTags == null)
            {
                throw new ReferenceNotLoadedException(nameof(ProductTags));
            }

            if (ProductTags.Any(x => x.ProductTagId == tagId))
            {
                ProductTags.RemoveAll(x => x.ProductTagId == tagId);
            }
        }

        public void AddDiscount(Guid discountId)
        {
            ProductDiscounts.Add(new ProductDiscount(Id, discountId));
        }

        public void RemoveDiscount(Guid discountId)
        {
            if (ProductDiscounts == null)
            {
                throw new ReferenceNotLoadedException(nameof(ProductDiscounts));
            }

            if (ProductDiscounts.Any(x => x.DiscountId == discountId))
            {
                ProductDiscounts.RemoveAll(x => x.DiscountId == discountId);
            }
        }

        public void AddCrossSellProduct(Guid crossSellProductId)
        {
            CrossSellProducts.Add(new CrossSellProduct(Id, crossSellProductId));
        }

        public void RemoveCrossSellProduct(Guid crossSellProductId)
        {
            if (CrossSellProducts == null)
            {
                throw new ReferenceNotLoadedException(nameof(CrossSellProducts));
            }

            if (CrossSellProducts.Any(x => x.CrossSellProductId == crossSellProductId))
            {
                CrossSellProducts.RemoveAll(x => x.CrossSellProductId == crossSellProductId);
            }
        }

        public void AddRelatedProduct(Guid relatedProductId)
        {
            RelatedProducts.Add(new RelatedProduct(Id, relatedProductId));
        }

        public void RemoveRelatedProduct(Guid relatedProductId)
        {
            if (RelatedProducts == null)
            {
                throw new ReferenceNotLoadedException(nameof(RelatedProducts));
            }

            if (RelatedProducts.Any(x => x.RelatedProductId == relatedProductId))
            {
                RelatedProducts.RemoveAll(x => x.RelatedProductId == relatedProductId);
            }
        }
    }
}
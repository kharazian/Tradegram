using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Exceptions;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Etos;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public class Product : FullAuditedAggregateRoot<Guid>
    {
        #region Grouped product

        public int ProductTypeId { get; protected set; }
        public bool VisibleIndividually { get; set; }
        public Guid? ParentGroupedProductId { get; protected set; }

        public ProductType ProductType
        {
            get => (ProductType) ProductTypeId;
            set => ProductTypeId = (int) value;
        }

        public void SetParentGroupedProduct(Guid? parentGroupedProductId)
        {
            if (parentGroupedProductId == Guid.Empty || parentGroupedProductId == null)
            {
                ParentGroupedProductId = null;
                ProductType = ProductType.SimpleProduct;
                VisibleIndividually = true;

                return;
            }

            ProductTypeId = (int) ProductType.GroupedProduct;
            ParentGroupedProductId = parentGroupedProductId;
            VisibleIndividually = false;
        }

        #endregion

        #region General

        public Guid ProductTemplateId { get; protected set; }
        public string Name { get; protected set; }
        public string ShortDescription { get; protected set; }
        public string FullDescription { get; protected set; }
        public string Code { get; private set; }
        public bool Published { get; set; }
        public string Gtin { get; protected set; }
        public string ManufacturerPartNumber { get; set; }
        public bool ShowOnHomePage { get; set; }
        public int DisplayOrder { get; set; }
        public double RatingAverage { get; protected set; }
        public int RatingCount { get; protected set; }
        public DateTime? AvailableStartDate { get; protected set; }
        public DateTime? AvailableEndDate { get; protected set; }
        public bool MarkAsNew { get; protected set; }
        public DateTime? MarkAsNewStartDate { get; protected set; }
        public DateTime? MarkAsNewEndDate { get; protected set; }
        public ICollection<ProductProductTag> ProductTags { get; protected set; }

        public void SetProductTemplate(Guid productTemplateId)
        {
            if (productTemplateId == Guid.Empty)
            {
                throw new InvalidIdentityException(nameof(productTemplateId));
            }

            ProductTemplateId = productTemplateId;
        }

        public void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (name.Length >= ProductConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {ProductConsts.MaxNameLength}");
            }

            Name = name;
        }

        public void SetShortDescription([NotNull] string shortDescription)
        {
            Check.NotNullOrWhiteSpace(shortDescription, nameof(shortDescription));

            if (shortDescription.Length >= ProductConsts.MaxShortDescriptionLength)
            {
                throw new ArgumentException(
                    $"Short description can not be longer than {ProductConsts.MaxShortDescriptionLength}");
            }

            ShortDescription = shortDescription;
        }

        public void SetFullDescription(string fullDescription)
        {
            if (fullDescription.Length >= ProductConsts.MaxDescriptionLength)
            {
                throw new ArgumentException($"Description can not be longer than {ProductConsts.MaxDescriptionLength}");
            }

            FullDescription = fullDescription;
        }

        public void SetGtin(string gtin)
        {
            if (gtin.Length > ProductConsts.MaxGtinLength)
            {
                throw new ArgumentException($"{nameof(gtin)} can not be longer than {ProductConsts.MaxGtinLength}");
            }

            Gtin = gtin;
        }

        public void AddTag(Guid tagId)
        {
            ProductTags.Add(new ProductProductTag(Id, tagId));
        }

        public void RemoveTag(Guid tagId)
        {
            if (ProductTags.Any(x => x.ProductTagId == tagId)) ProductTags.RemoveAll(x => x.ProductTagId == tagId);
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

        public void SetAvailableDate(DateTime startDate, DateTime? endDate)
        {
            if (startDate < DateTime.Now)
            {
                startDate = DateTime.Now;
            }

            if (endDate.HasValue && endDate <= startDate)
            {
                endDate = DateTime.Now.AddMonths(1);
            }

            AvailableStartDate = startDate;
            AvailableEndDate = endDate;
        }

        public void SetAsNew(bool markAsNew = true, DateTime? startDate = null, DateTime? endDate = null)
        {
            if (markAsNew)
            {
                if (startDate.HasValue && startDate < DateTime.Now) startDate = DateTime.Now;

                if (endDate.HasValue && endDate <= startDate)
                    throw new ArgumentException("Can not set end date in the past of start date!", nameof(endDate));

                MarkAsNew = true;
                MarkAsNewStartDate = startDate;
                MarkAsNewEndDate = endDate;

                return;
            }

            MarkAsNew = false;
            MarkAsNewStartDate = null;
            MarkAsNewEndDate = null;
        }

        #endregion

        #region GiftCard

        public bool IsGiftCard { get; set; }
        public int GiftCardTypeId { get; set; }
        public decimal? OverriddenGiftCardAmount { get; set; }

        public GiftCardType GiftCardType
        {
            get => (GiftCardType) GiftCardTypeId;
            set => GiftCardTypeId = (int) value;
        }

        public void SetAsGiftCard(bool isGiftCard = true, int? giftCardTypeId = null,
            decimal? overriddenGiftCardAmount = null)
        {
            if (isGiftCard && giftCardTypeId.HasValue)
            {
                switch (giftCardTypeId)
                {
                    case 0:
                        IsGiftCard = true;
                        GiftCardTypeId = (int) giftCardTypeId;

                        //TODO: is virtual! disable all physical prop!
                        break;
                    case 1:
                        IsGiftCard = true;
                        GiftCardTypeId = (int) giftCardTypeId;

                        //TODO: is physical! disable all virtual prop! 
                        break;
                    default:
                        IsGiftCard = true;
                        GiftCardTypeId = 0;

                        //TODO: is virtual! disable all physical prop!
                        break;
                }

                if (overriddenGiftCardAmount <= decimal.Zero || overriddenGiftCardAmount == null)
                {
                    OverriddenGiftCardAmount = decimal.Zero;
                }

                return;
            }

            IsGiftCard = false;
            GiftCardTypeId = 0;
            OverriddenGiftCardAmount = decimal.Zero;
        }

        #endregion

        #region Downloadable

        public bool IsDownload { get; protected set; }
        public Guid? DownloadId { get; protected set; }
        public bool UnlimitedDownloads { get; protected set; }
        public int MaxNumberOfDownloads { get; protected set; }
        public int? DownloadExpirationDays { get; protected set; }
        public int DownloadActivationTypeId { get; protected set; }
        public bool HasSampleDownload { get; protected set; }
        public Guid? SampleDownloadId { get; protected set; }

        public DownloadActivationType DownloadActivationType
        {
            get => (DownloadActivationType) DownloadActivationTypeId;
            set => DownloadActivationTypeId = (int) value;
        }

        public void SetAsDownloadable(Guid? downloadId, bool unlimitedDownloads, int maxNumberOfDownloads,
            int? downloadExpirationDays, bool hasSampleDownload, Guid? sampleDownloadId,
            int downloadActivationTypeId)
        {
            if (downloadId == Guid.Empty || downloadId == null)
            {
                IsDownload = false;

                return;
            }

            if (!unlimitedDownloads && maxNumberOfDownloads <= 0)
            {
                unlimitedDownloads = true;
            }

            if (hasSampleDownload && !sampleDownloadId.HasValue)
            {
                hasSampleDownload = false;
            }

            if (downloadExpirationDays.HasValue && downloadExpirationDays.Value <= 0)
            {
                downloadExpirationDays = 1;
            }

            DownloadId = downloadId;
            UnlimitedDownloads = unlimitedDownloads;
            MaxNumberOfDownloads = maxNumberOfDownloads;
            DownloadExpirationDays = downloadExpirationDays;
            HasSampleDownload = hasSampleDownload;
            SampleDownloadId = sampleDownloadId;
            DownloadActivationTypeId = downloadActivationTypeId;

            //TODO: Disable non-download properties(shipping, stock props, ...)
        }

        #endregion
        
        #region Recurring Product

        public bool IsRecurring { get; protected set; }
        public int RecurringCycleLength { get; protected set; }
        public int RecurringCyclePeriodId { get; protected set; }
        public int RecurringTotalCycles { get; protected set; }

        public RecurringProductCyclePeriod RecurringCyclePeriod
        {
            get => (RecurringProductCyclePeriod) RecurringCyclePeriodId;
            set => RecurringCyclePeriodId = (int) value;
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

        #endregion
        
        #region Rental Product

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

        #endregion
        
        #region Price
        public decimal Price { get; protected set; }
        public decimal OldPrice { get; protected set; }
        public decimal ProductCost { get; set; }
        public bool DisableBuyButton { get; set; }
        public bool DisableWishListButton { get; set; }
        public bool CallForPrice { get; set; }

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
        
        #region Customer Enters Price
        public bool CustomerEntersPrice { get; protected set; }
        public decimal MinimumCustomerEnteredPrice { get; protected set; }
        public decimal MaximumCustomerEnteredPrice { get; protected set; }
        public void AllowCustomerEntersPrice(bool allow = false, decimal? minPrice = null, decimal? maxPerice = null)
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
        
        #region PAngV (base price) 
        public bool BasePriceEnabled { get; set; }
        public decimal BasePriceAmount { get; set; }
        public int BasePriceUnitId { get; set; }
        public decimal BasePriceBaseAmount { get; set; }
        public int BasePriceBaseUnitId { get; set; }
        #endregion

        #region Discount

        public bool HasDiscountsApplied { get; set; }
        
        public ICollection<ProductDiscount> ProductDiscounts { get; protected set; }

        public void AddDiscount(Guid discountId)
        {
            ProductDiscounts.Add(new ProductDiscount(Id, discountId));
        }

        public void RemoveDiscount(Guid discountId)
        {
            if (ProductDiscounts.Any(x => x.DiscountId == discountId))
                ProductDiscounts.RemoveAll(x => x.DiscountId == discountId);
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
                IsTaxExempt = true;
                TaxCategoryId = null;

                return;
            }

            TaxCategoryId = taxCategoryId;
            IsTaxExempt = false;
        }

        #endregion

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
        
        #endregion

        #region Inventory

        //TODO: full review
        public int ManageInventoryMethodId { get; protected set; }
        
        public ManageInventoryMethod ManageInventoryMethod
        {
            get => (ManageInventoryMethod) ManageInventoryMethodId;
            protected set => ManageInventoryMethodId = (int) value;
        }
        public int StockQuantity { get; protected set; }
        public Guid? WarehouseId { get; protected set; }
        public bool UseMultipleWarehouses { get; protected set; } 
        public int ProductAvailabilityRangeId { get; set; }
        public bool DisplayStockAvailability { get; set; }
        public bool DisplayStockQuantity { get; set; }
        
        public int MinStockQuantity { get; set; }
        public int LowStockActivityId { get; protected set; }
        public LowStockActivity LowStockActivity
        {
            get => (LowStockActivity) LowStockActivityId;
            protected set => LowStockActivityId = (int) value;
        }
        public int NotifyAdminForQuantityBelow { get; set; }
        public int BackorderModeId { get; set; }
        public BackorderMode BackorderMode
        {
            get => (BackorderMode) BackorderModeId;
            set => BackorderModeId = (int) value;
        }
        public bool AllowBackInStockSubscriptions { get; set; }
        public int OrderMinimumQuantity { get; protected set; }
        public int OrderMaximumQuantity { get; protected set; }
        public void SetOrderQuantityLimitation(int orderMinimumQuantity, int orderMaximumQuantity)
        {
            if (orderMinimumQuantity <= 0 || orderMaximumQuantity <= 0 || orderMaximumQuantity < orderMinimumQuantity)
            {
                orderMinimumQuantity = 1;
                orderMaximumQuantity = int.MaxValue;
            }

            OrderMinimumQuantity = orderMinimumQuantity;
            OrderMaximumQuantity = orderMaximumQuantity;
        }
        public string AllowedQuantities { get; protected set; }

        public void SetAllowedQuantities(IEnumerable<int> allowedQuantities)
        {
            allowedQuantities = allowedQuantities.Distinct().ToArray();

            if (!string.IsNullOrWhiteSpace(AllowedQuantities))
            {
                AllowedQuantities = "";
            }

            AllowedQuantities = string.Join(",", allowedQuantities);
        }

        public bool NotReturnable { get; set; }
        public ICollection<ProductWarehouseInventory> ProductWarehouseInventories { get; protected set; }

        public void SetManageInventoryMethod(int manageInventoryMethodId = 0)
        {
            var manageMethod = (ManageInventoryMethod) manageInventoryMethodId;

            switch (manageMethod)
            {
                case ManageInventoryMethod.ManageStock:
                    ManageInventoryMethod = manageMethod;
                    break;
                
                case ManageInventoryMethod.DontManageStock:
                    ManageInventoryMethod = manageMethod;
                    UseMultipleWarehouses = false;
                    DisplayStockQuantity = false;
                    DisplayStockAvailability = false;
                    LowStockActivity = LowStockActivity.Nothing;
                    BackorderMode = BackorderMode.NoBackorders;
                    AllowBackInStockSubscriptions = false;
                    ProductAvailabilityRangeId = 0;
                    break;
 
                case ManageInventoryMethod.ManageStockByAttributes:
                    ManageInventoryMethod = manageMethod;
                    break;

                default:
 
                    throw new ArgumentOutOfRangeException();
            }
        }
        public void SetWarehouse(Guid? warehouseId)
        {
            if (warehouseId == null || warehouseId == Guid.Empty)
            {
                WarehouseId = null;

                return;
            }

            WarehouseId = warehouseId;
        }
        
        public void SetMultipleWarehouses(IEnumerable<Guid> warehouseInventoryIds)
        {
            var hashSet = new HashSet<Guid>(warehouseInventoryIds);
            
            if (hashSet.Count <= 1)
            {
                UseMultipleWarehouses = false;
                SetWarehouse(hashSet.FirstOrDefault());
                return;
            }

            UseMultipleWarehouses = true;
            StockQuantity = 0;
            WarehouseId = null;
            
            if (ManageInventoryMethod == ManageInventoryMethod.DontManageStock)
            {
                SetManageInventoryMethod();
            }
            
            foreach (var warehouseInventoryId in hashSet)
            {
                ProductWarehouseInventories.Add(new ProductWarehouseInventory(Id, warehouseInventoryId));
            }
        }

        #endregion
        
        #region Require Products

        public bool RequireOtherProducts { get; protected set; }
        public string RequiredProductIds { get; protected set; }
        public bool AutomaticallyAddRequiredProducts { get; set; }

        public void SetRequireProducts(bool requireOtherProducts = false, string requireProductIds = "")
        {
            if (requireOtherProducts)
            {
                if (requireProductIds.IsNullOrWhiteSpace())
                {
                    RequireOtherProducts = false;
                    RequiredProductIds = "";

                    return;
                }
                RequireOtherProducts = true;
                RequiredProductIds = requireProductIds;
                return;
            }
            
            RequireOtherProducts = false;
            RequiredProductIds = "";
        }
        

        #endregion

        #region SEO

        public string MetaKeywords { get; protected set; }
        public string MetaDescription { get; protected set; }
        public string MetaTitle { get; protected set; }

        public void SetMetaData(string metaTitle, string metaKeywords, string metaDescription)
        {
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

        #endregion

        public bool HasUserAgreement { get; set; }
        public string UserAgreementText { get; set; }
        public bool IsShipEnabled { get; set; }
        public bool IsFreeShipping { get; set; }
        public bool ShipSeparately { get; set; }
        public decimal AdditionalShippingCharge { get; set; }
        public int DeliveryDateId { get; set; }


        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }


        #region Mapping

        public ICollection<ProductCategory> ProductCategories { get; protected set; }

        public void AddCategory(Guid categoryId)
        {
            ProductCategories.Add(new ProductCategory(Id, categoryId));
        }

        public void RemoveCategory(Guid categoryId)
        {
            if (ProductCategories.Any(x => x.CategoryId == categoryId))
                ProductCategories.RemoveAll(x => x.CategoryId == categoryId);
        }

        public ICollection<ProductManufacturer> ProductManufacturers { get; protected set; }

        public void AddManufacturer(Guid manufacturerId)
        {
            ProductManufacturers.Add(new ProductManufacturer(Id, manufacturerId));
        }

        public void RemoveManufacturer(Guid manufacturerId)
        {
            if (ProductManufacturers.Any(x => x.ManufacturerId == manufacturerId))
                ProductManufacturers.RemoveAll(x => x.ManufacturerId == manufacturerId);
        }

        public Guid? VendorId { get; protected set; }

        public void SetVendor(Guid? vendorId)
        {
            if (vendorId == Guid.Empty || vendorId == null)
            {
                VendorId = null;

                return;
            }

            VendorId = vendorId;
        }

        #endregion

        #region Related data

        public ICollection<ProductPicture> ProductPictures { get; protected set; }

        public void AddPicture(Guid pictureId)
        {
            ProductPictures.Add(new ProductPicture(Id, pictureId));
        }

        public void RemovePicture(Guid pictureId)
        {
            if (ProductPictures.Any(x => x.PictureId == pictureId))
                ProductPictures.RemoveAll(x => x.PictureId == pictureId);
        }


        public ICollection<ProductProductAttribute> ProductProductAttributes { get; protected set; }

        public void AddProductAttribute(Guid productAttributeId)
        {
            ProductProductAttributes.Add(new ProductProductAttribute(Id, productAttributeId));
        }

        public void RemoveProductAttribute(Guid productAttributeId)
        {
            if (ProductProductAttributes.Any(x => x.ProductAttributeId == productAttributeId))
            {
                ProductProductAttributes.RemoveAll(x => x.ProductAttributeId == productAttributeId);
            }
        }

        public ICollection<CrossSellProduct> CrossSellProducts { get; protected set; }

        public void AddCrossSellProduct(Guid crossSellProductId)
        {
            CrossSellProducts.Add(new CrossSellProduct(Id, crossSellProductId));
        }

        public void RemoveCrossSellProduct(Guid crossSellProductId)
        {
            if (CrossSellProducts.Any(x => x.CrossSellProductId == crossSellProductId))
                CrossSellProducts.RemoveAll(x => x.CrossSellProductId == crossSellProductId);
        }

        public ICollection<RelatedProduct> RelatedProducts { get; protected set; }

        public void AddRelatedProduct(Guid relatedProductId)
        {
            RelatedProducts.Add(new RelatedProduct(Id, relatedProductId));
        }

        public void RemoveRelatedProduct(Guid relatedProductId)
        {
            if (RelatedProducts == null) throw new ReferenceNotLoadedException(nameof(RelatedProducts));

            if (RelatedProducts.Any(x => x.RelatedProductId == relatedProductId))
                RelatedProducts.RemoveAll(x => x.RelatedProductId == relatedProductId);
        }

        public ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes { get; protected set; }

        public void AddSpecificationAttribute(Guid specificationAttributeOptionId)
        {
            ProductSpecificationAttributes.Add(new ProductSpecificationAttribute(Id, specificationAttributeOptionId));
        }

        public void RemoveSpecificationAttribute(Guid specificationAttributeOptionId)
        {
            if (ProductSpecificationAttributes.Any(x =>
                x.SpecificationAttributeOptionId == specificationAttributeOptionId))
            {
                ProductSpecificationAttributes.RemoveAll(x =>
                    x.SpecificationAttributeOptionId == specificationAttributeOptionId);
            }
        }

        public ICollection<ProductAttributeCombination> ProductAttributeCombinations { get; protected set; }

        #endregion

        protected Product()
        {
        }

        public Product(Guid id, [NotNull] string code, [NotNull] string name, [NotNull] string shortDescription,
            decimal price)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));

            if (code.Length > ProductConsts.MaxCodeLength)
                throw new ArgumentException($"Code can not be longer than {ProductConsts.MaxCodeLength}");

            if (price < decimal.Zero) throw new ArgumentException($"{nameof(price)} can not be less than 0.0!");

            Id = id;
            Code = code;
            Price = price;
            SetName(name);
            SetShortDescription(shortDescription);

            ProductCategories = new HashSet<ProductCategory>();
            ProductManufacturers = new HashSet<ProductManufacturer>();
            ProductPictures = new HashSet<ProductPicture>();
            ProductSpecificationAttributes = new HashSet<ProductSpecificationAttribute>();
            ProductTags = new HashSet<ProductProductTag>();
            ProductProductAttributes = new HashSet<ProductProductAttribute>();
            ProductDiscounts = new HashSet<ProductDiscount>();
            ProductAttributeCombinations = new HashSet<ProductAttributeCombination>();
            CrossSellProducts = new HashSet<CrossSellProduct>();
            RelatedProducts = new HashSet<RelatedProduct>();
            ProductWarehouseInventories = new HashSet<ProductWarehouseInventory>();
        }
    }
}
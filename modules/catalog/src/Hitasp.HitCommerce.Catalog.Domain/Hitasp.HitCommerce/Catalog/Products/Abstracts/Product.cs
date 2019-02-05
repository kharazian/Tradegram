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

namespace Hitasp.HitCommerce.Catalog.Products.Abstracts
{
    public abstract class Product : FullAuditedAggregateRoot<Guid>
    {
        #region General

        public virtual ProductType ProductType { get; set; }
        public virtual Guid ProductTemplateId { get; protected set; }
        public virtual string Name { get; protected set; }
        public virtual string ShortDescription { get; protected set; }
        public virtual string FullDescription { get; protected set; }
        public virtual string Code { get; protected set; }
        public virtual string Gtin { get; protected set; }
        public virtual string ManufacturerPartNumber { get; set; }
        public virtual bool ShowOnHomePage { get; set; }
        public virtual int DisplayOrder { get; set; }
        public virtual double RatingAverage { get; protected set; }
        public virtual int RatingCount { get; protected set; }
        public virtual DateTime? AvailableStartDate { get; protected set; }
        public virtual DateTime? AvailableEndDate { get; protected set; }
        public virtual bool MarkAsNew { get; protected set; }
        public virtual DateTime? MarkAsNewStartDate { get; protected set; }
        public virtual DateTime? MarkAsNewEndDate { get; protected set; }
        public virtual bool Published { get; set; }

        public virtual ICollection<ProductProductTag> ProductTags { get; protected set; }

        public virtual void SetProductTemplate(Guid productTemplateId)
        {
            if (productTemplateId == Guid.Empty) throw new InvalidIdentityException(nameof(productTemplateId));

            ProductTemplateId = productTemplateId;
        }

        internal void SetCode(string code)
        {
            if (!Code.IsNullOrWhiteSpace()) throw new ArgumentException($"Code is unique and is readonly!");

            Check.NotNullOrWhiteSpace(code, nameof(code));

            if (code.Length > ProductConsts.MaxCodeLength)
                throw new ArgumentException($"Code can not be longer than {ProductConsts.MaxCodeLength}");

            Code = code;
        }

        public virtual void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (name.Length >= ProductConsts.MaxNameLength)
                throw new ArgumentException($"Name can not be longer than {ProductConsts.MaxNameLength}");

            Name = name;
        }

        public virtual void SetShortDescription([NotNull] string shortDescription)
        {
            Check.NotNullOrWhiteSpace(shortDescription, nameof(shortDescription));

            if (shortDescription.Length >= ProductConsts.MaxShortDescriptionLength)
                throw new ArgumentException(
                    $"Short description can not be longer than {ProductConsts.MaxShortDescriptionLength}");

            ShortDescription = shortDescription;
        }

        public virtual void SetFullDescription(string fullDescription)
        {
            if (fullDescription.Length >= ProductConsts.MaxDescriptionLength)
                throw new ArgumentException($"Description can not be longer than {ProductConsts.MaxDescriptionLength}");

            FullDescription = fullDescription;
        }

        public virtual void SetGtin(string gtin)
        {
            if (gtin.Length > ProductConsts.MaxGtinLength)
                throw new ArgumentException($"{nameof(gtin)} can not be longer than {ProductConsts.MaxGtinLength}");

            Gtin = gtin;
        }

        public virtual void AddTag(Guid tagId)
        {
            ProductTags.Add(new ProductProductTag(Id, tagId));
        }

        public virtual void RemoveTag(Guid tagId)
        {
            if (ProductTags.Any(x => x.ProductTagId == tagId)) ProductTags.RemoveAll(x => x.ProductTagId == tagId);
        }

        public virtual void UpdateRatingAverage(double newRate)
        {
            var average = (RatingAverage * RatingCount + newRate) / (RatingCount + 1);
            RatingAverage = Math.Round(average * 2, MidpointRounding.AwayFromZero) / 2;
            IncreaseRatingCount();
        }

        private void IncreaseRatingCount()
        {
            RatingCount++;
        }

        public virtual void SetAvailableDate(DateTime startDate, DateTime? endDate)
        {
            if (startDate < DateTime.Now) startDate = DateTime.Now;

            if (endDate.HasValue && endDate <= startDate) endDate = DateTime.Now.AddMonths(1);

            AvailableStartDate = startDate;
            AvailableEndDate = endDate;
        }

        public virtual void SetAsNew(bool markAsNew = false, DateTime? startDate = null, DateTime? endDate = null)
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

        #region Pricing

        #region BasePrice

        public virtual bool BasePriceEnabled { get; protected set; }
        public virtual ProductBasePrice ProductBasePrice { get; protected set; }

        public virtual void EnableBasePrice(bool basePriceEnabled, decimal basePriceAmount = decimal.Zero,
            int basePriceUnitId = 0, decimal basePriceBaseAmount = decimal.Zero, int basePriceBaseUnitId = 0)
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

                ProductBasePrice = new ProductBasePrice(basePriceAmount, basePriceUnitId,
                    basePriceBaseAmount, basePriceBaseUnitId);
            }
            else
            {
                BasePriceEnabled = false;
            }
        }

        #endregion

        #region Discounts

        public virtual bool HasDiscountsApplied { get; protected set; }

        public virtual ICollection<ProductDiscount> ProductDiscounts { get; protected set; }

        public virtual void AddDiscount(Guid discountId)
        {
            ProductDiscounts.Add(new ProductDiscount(Id, discountId));
            HasDiscountsApplied = true;
        }

        public virtual void RemoveDiscount(Guid discountId)
        {
            if (ProductDiscounts.Any(x => x.DiscountId == discountId))
                ProductDiscounts.RemoveAll(x => x.DiscountId == discountId);

            if (!ProductDiscounts.Any())
            {
                HasDiscountsApplied = false;
            }
        }

        #endregion

        public virtual ProductPricing Pricing { get; protected set; }

        public virtual void ChangePrice(decimal newPrice, bool triggerEvent = true)
        {
            if (newPrice < decimal.Zero) throw new ArgumentException($"{nameof(newPrice)} can not be less than 0.0!");

            if (Pricing.Price == newPrice) return;

            //sample distributed event
            if (triggerEvent) AddDistributedEvent(new ProductPriceChangedEto(Pricing.Price, newPrice));

            Pricing.SetPrice(newPrice);
        }

        #endregion

        #region RequiredProducts

        public virtual ICollection<RequiredProduct> RequiredProducts { get; protected set; }

        public virtual void AddRequiredProduct(Guid requiredProductId)
        {
            RequiredProducts.Add(new RequiredProduct(Id, requiredProductId));
        }

        public virtual void RemoveRequiredProduct(Guid requiredProductId)
        {
            if (RequiredProducts.Any(x => x.RequiredProductId == requiredProductId))
                RequiredProducts.RemoveAll(x => x.RequiredProductId == requiredProductId);
        }

        #endregion

        #region Related Products

        public virtual ICollection<RelatedProduct> RelatedProducts { get; protected set; }

        public virtual void AddRelatedProduct(Guid relatedProductId)
        {
            RelatedProducts.Add(new RelatedProduct(Id, relatedProductId));
        }

        public virtual void RemoveRelatedProduct(Guid relatedProductId)
        {
            if (RelatedProducts == null) throw new ReferenceNotLoadedException(nameof(RelatedProducts));

            if (RelatedProducts.Any(x => x.RelatedProductId == relatedProductId))
                RelatedProducts.RemoveAll(x => x.RelatedProductId == relatedProductId);
        }

        #endregion

        #region CrossSell Products

        public virtual ICollection<CrossSellProduct> CrossSellProducts { get; protected set; }

        public virtual void AddCrossSellProduct(Guid crossSellProductId)
        {
            CrossSellProducts.Add(new CrossSellProduct(Id, crossSellProductId));
        }

        public virtual void RemoveCrossSellProduct(Guid crossSellProductId)
        {
            if (CrossSellProducts.Any(x => x.CrossSellProductId == crossSellProductId))
                CrossSellProducts.RemoveAll(x => x.CrossSellProductId == crossSellProductId);
        }

        #endregion

        #region Mapping

        public virtual ICollection<ProductCategory> ProductCategories { get; protected set; }

        public virtual void AddCategory(Guid categoryId)
        {
            ProductCategories.Add(new ProductCategory(Id, categoryId));
        }

        public virtual void RemoveCategory(Guid categoryId)
        {
            if (ProductCategories.Any(x => x.CategoryId == categoryId))
                ProductCategories.RemoveAll(x => x.CategoryId == categoryId);
        }

        public virtual ICollection<ProductManufacturer> ProductManufacturers { get; protected set; }

        public virtual void AddManufacturer(Guid manufacturerId)
        {
            ProductManufacturers.Add(new ProductManufacturer(Id, manufacturerId));
        }

        public virtual void RemoveManufacturer(Guid manufacturerId)
        {
            if (ProductManufacturers.Any(x => x.ManufacturerId == manufacturerId))
                ProductManufacturers.RemoveAll(x => x.ManufacturerId == manufacturerId);
        }

        public virtual Guid? VendorId { get; protected set; }

        public virtual void SetVendor(Guid? vendorId)
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

        #region SEO

        public virtual string MetaKeywords { get; protected set; }
        public virtual string MetaDescription { get; protected set; }
        public virtual string MetaTitle { get; protected set; }

        public virtual void SetMetaData(string metaTitle, string metaKeywords, string metaDescription)
        {
            if (metaTitle.Length >= ProductConsts.MaxMetaTitleLength)
                throw new ArgumentException(
                    $"Meta Title can not be longer than {ProductConsts.MaxMetaTitleLength}");

            if (metaKeywords.Length >= ProductConsts.MaxMetaKeywordsLength)
                throw new ArgumentException(
                    $"Meta Keywords can not be longer than {ProductConsts.MaxMetaKeywordsLength}");

            if (metaDescription.Length >= ProductConsts.MaxMetaDescriptionLength)
                throw new ArgumentException(
                    $"Meta Description can not be longer than {ProductConsts.MaxMetaDescriptionLength}");

            MetaTitle = metaTitle;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
        }

        #endregion

        #region Pictures

        public virtual ICollection<ProductPicture> ProductPictures { get; protected set; }

        public virtual void AddPicture(Guid pictureId)
        {
            ProductPictures.Add(new ProductPicture(Id, pictureId));
        }

        public virtual void RemovePicture(Guid pictureId)
        {
            if (ProductPictures.Any(x => x.PictureId == pictureId))
                ProductPictures.RemoveAll(x => x.PictureId == pictureId);
        }

        #endregion

        #region Product Attributes

        public virtual ICollection<ProductProductAttribute> ProductProductAttributes { get; protected set; }

        public virtual void AddProductAttribute(Guid productAttributeId)
        {
            ProductProductAttributes.Add(new ProductProductAttribute(Id, productAttributeId));
        }

        public virtual void RemoveProductAttribute(Guid productAttributeId)
        {
            if (ProductProductAttributes.Any(x => x.ProductAttributeId == productAttributeId))
            {
                ProductProductAttributes.RemoveAll(x => x.ProductAttributeId == productAttributeId);
            }
        }

        #endregion

        #region Specification Attributes

        public virtual ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes { get; protected set; }

        public virtual void AddSpecificationAttribute(Guid specificationAttributeOptionId)
        {
            ProductSpecificationAttributes.Add(new ProductSpecificationAttribute(Id, specificationAttributeOptionId));
        }

        public virtual void RemoveSpecificationAttribute(Guid specificationAttributeOptionId)
        {
            if (ProductSpecificationAttributes.Any(x =>
                x.SpecificationAttributeOptionId == specificationAttributeOptionId))
                ProductSpecificationAttributes.RemoveAll(x =>
                    x.SpecificationAttributeOptionId == specificationAttributeOptionId);
        }

        #endregion

        #endregion
    }
}
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

        public void SetAsNew(bool markAsNew = false, DateTime? startDate = null, DateTime? endDate = null)
        {
            if (markAsNew)
            {
                if (startDate.HasValue && startDate < DateTime.Now)
                {
                    startDate = DateTime.Now;
                }

                if (endDate.HasValue && endDate <= startDate)
                {
                    throw new ArgumentException("Can not set end date in the past of start date!", nameof(endDate));
                }

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

        

        #region RequiredProducts

        public void SetRequireProducts(bool requireOtherProducts, string requireProductIds)
        {
            RequiredProductIds = string.Empty;

            if (requireOtherProducts && !requireProductIds.IsNullOrWhiteSpace())
            {
                var validProductIds = requireProductIds.Split(",").Where(g => Guid.TryParse(g, out _))
                    .Select(Guid.Parse)
                    .ToArray();

                if (validProductIds.Any())
                {
                    RequireOtherProducts = true;
                    RequiredProductIds = string.Join(",", validProductIds);

                    return;
                }

                RequireOtherProducts = false;

                return;
            }

            RequireOtherProducts = false;
        }

        #endregion

        #region Related Products

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

        #endregion

        #region CrossSell Products

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

        #endregion

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

        #region Pictures

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

        #endregion

        #region Product Attributes

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

        #endregion

        #region Specification Attributes

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

        #endregion

        public ICollection<ProductAttributeCombination> ProductAttributeCombinations { get; protected set; }

        #endregion
    }
}
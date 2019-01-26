using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public abstract class Product : FullAuditedAggregateRoot<Guid>
    {
        public string ProductType { get; protected set; }

        public Guid? SpaceId { get; protected set; }

        public Guid ProductTemplateId { get; protected set; }

        public Guid ProductCodeId { get; protected set; }

        public ProductCode ProductCode { get; protected set; }

        public Guid ProductInfoId { get; protected set; }

        public ProductInfo ProductInfo { get; protected set; }

        public Guid ProductMetaId { get; protected set; }

        public ProductMeta ProductMeta { get; protected set; }

        public Guid ProductPriceInfoId { get; protected set; }

        public ProductPriceInfo ProductPriceInfo { get; protected set; }

        public Guid ProductPublishingInfoId { get; protected set; }

        public ProductPublishingInfo ProductPublishingInfo { get; protected set; }

        public Guid ProductOrderingInfoId { get; protected set; }

        public ProductOrderingInfo ProductOrderingInfo { get; protected set; }

        public Guid ProductRateId { get; protected set; }

        public ProductRate ProductRate { get; protected set; }

        public Guid ProductShippingInfoId { get; protected set; }

        public ProductShippingInfo ProductShippingInfo { get; protected set; }

        public ICollection<ProductCategory> ProductCategories { get; protected set; }

        public ICollection<ProductManufacturer> ProductManufacturers { get; protected set; }

        public ICollection<ProductPicture> ProductPictures { get; protected set; }

        public ICollection<ProductTag> ProductTags { get; protected set; }

        public ICollection<ProductDiscount> ProductDiscounts { get; protected set; }

        public ICollection<ProductAttribute> ProductAttributes { get; protected set; }
        
        public ICollection<CrossSellProduct> CrossSellProducts { get; protected set; }
        
        public ICollection<RelatedProduct> RelatedProducts { get; protected set; }

        public ICollection<ProductSpecificationAttribute> ProductSpecificationAttributes { get; protected set; }

        public ICollection<ProductAttributeCombination> AttributeCombinations { get; protected set; }


        internal void SetSpace(Guid? spaceId)
        {
            if (spaceId == Guid.Empty || !spaceId.HasValue)
            {
                SpaceId = null;
            }

            if (SpaceId == spaceId)
            {
                return;
            }

            SpaceId = spaceId;
        }

        internal void SetProductTemplate(Guid productTemplateId)
        {
            if (productTemplateId == Guid.Empty)
            {
                throw new ArgumentException($"{nameof(productTemplateId)} must be a valid identity");
            }

            if (ProductTemplateId == productTemplateId)
            {
                return;
            }

            ProductTemplateId = productTemplateId;
        }

        internal void SetProductCode(ProductCode productCode)
        {
            ProductCodeId = productCode.Id;
            ProductCode = productCode;
        }

        internal void SetProductInfo(ProductInfo productInfo)
        {
            ProductInfoId = productInfo.Id;
            ProductInfo = productInfo;
        }

        internal void SetProductMetaData(ProductMeta productMetaData)
        {
            ProductMetaId = productMetaData.Id;
            ProductMeta = productMetaData;
        }

        internal void SetProductPriceInfo(ProductPriceInfo productPriceInfo)
        {
            ProductPriceInfoId = productPriceInfo.Id;
            ProductPriceInfo = productPriceInfo;
        }

        internal void SetProductPublishingInfo(ProductPublishingInfo productPublishingInfo)
        {
            ProductPublishingInfoId = productPublishingInfo.Id;
            ProductPublishingInfo = productPublishingInfo;
        }

        internal void SetProductOrderingInfo(ProductOrderingInfo productOrderingInfo)
        {
            ProductOrderingInfoId = productOrderingInfo.Id;
            ProductOrderingInfo = productOrderingInfo;
        }

        internal void SetProductRate(ProductRate productRate)
        {
            ProductRateId = productRate.Id;
            ProductRate = productRate;
        }

        internal void SetProductShippingInfo(ProductShippingInfo productShippingInfo)
        {
            ProductShippingInfoId = productShippingInfo.Id;
            ProductShippingInfo = productShippingInfo;
        }

        public void AddCategory(Guid categoryId)
        {
            ProductCategories.Add(new ProductCategory(Id, categoryId));
        }

        public void RemoveCategory(Guid categoryId)
        {
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
            if (ProductSpecificationAttributes.Any(x =>
                x.SpecificationAttributeOptionId == specificationAttributeOptionId))
            {
                ProductSpecificationAttributes.RemoveAll(x =>
                    x.SpecificationAttributeOptionId == specificationAttributeOptionId);
            }
        }

        public void AddTag(Guid tagId)
        {
            ProductTags.Add(new ProductTag(Id, tagId));
        }

        public void RemoveTag(Guid tagId)
        {
            if (ProductTags.Any(x => x.TagId == tagId))
            {
                ProductTags.RemoveAll(x => x.TagId == tagId);
            }
        }

        public void AddDiscount(Guid discountId)
        {
            ProductDiscounts.Add(new ProductDiscount(Id, discountId));
        }

        public void RemoveDiscount(Guid discountId)
        {
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
            if (RelatedProducts.Any(x => x.RelatedProductId == relatedProductId))
            {
                RelatedProducts.RemoveAll(x => x.RelatedProductId == relatedProductId);
            }
        }
    }
}
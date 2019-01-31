using System;
using System.Collections.Generic;
using System.Linq;
using Hitasp.HitCommerce.Catalog.Exceptions;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public abstract class Product : FullAuditedAggregateRoot<Guid>
    {
        public string ProductType { get; protected set; }

        public Guid ProductTemplateId { get; protected set; }

        public Guid? PictureId { get; protected set; }

        public ProductCode ProductCode { get; protected set; }

        public ProductInfo ProductInfo { get; protected set; }

        public ProductMetaInfo ProductMetaInfo { get; protected set; }

        public ProductPriceInfo ProductPriceInfo { get; protected set; }

        public ProductPublishingInfo ProductPublishingInfo { get; protected set; }

        public ProductOrderingInfo ProductOrderingInfo { get; protected set; }

        public ProductRate ProductRate { get; protected set; }

        public ProductShippingInfo ProductShippingInfo { get; protected set; }

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

        internal void SetProductCode(ProductCode productCode)
        {
            if (Id != productCode.Id)
            {
                throw new InvalidIdentityException(nameof(productCode));
            }

            ProductCode = productCode;
        }

        internal void SetProductInfo(ProductInfo productInfo)
        {
            if (Id != productInfo.Id)
            {
                throw new InvalidIdentityException(nameof(productInfo));
            }

            ProductInfo = productInfo;
        }

        internal void SetProductMetaInfo(ProductMetaInfo productMetaInfo)
        {
            if (Id != productMetaInfo.Id)
            {
                throw new InvalidIdentityException(nameof(productMetaInfo));
            }

            ProductMetaInfo = productMetaInfo;
        }

        internal void SetProductOrderingInfo(ProductOrderingInfo productOrderingInfo)
        {
            if (Id != productOrderingInfo.Id)
            {
                throw new InvalidIdentityException(nameof(productOrderingInfo));
            }

            ProductOrderingInfo = productOrderingInfo;
        }

        internal void SetProductPriceInfo(ProductPriceInfo productPriceInfo)
        {
            if (Id != productPriceInfo.Id)
            {
                throw new InvalidIdentityException(nameof(productPriceInfo));
            }

            ProductPriceInfo = productPriceInfo;
        }

        internal void SetProductPublishingInfo(ProductPublishingInfo productPublishingInfo)
        {
            if (Id != productPublishingInfo.Id)
            {
                throw new InvalidIdentityException(nameof(productPublishingInfo));
            }

            ProductPublishingInfo = productPublishingInfo;
        }

        internal void SetProductRate(ProductRate productRate)
        {
            if (Id != productRate.Id)
            {
                throw new InvalidIdentityException(nameof(productRate));
            }

            ProductRate = productRate;
        }

        internal void SetProductShippingInfo(ProductShippingInfo productShippingInfo)
        {
            if (Id != productShippingInfo.Id)
            {
                throw new InvalidIdentityException(nameof(productShippingInfo));
            }

            ProductShippingInfo = productShippingInfo;
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
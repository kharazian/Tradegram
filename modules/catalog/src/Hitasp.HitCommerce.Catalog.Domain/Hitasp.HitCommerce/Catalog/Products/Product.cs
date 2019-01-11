using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Hitasp.HitCommon.Contents;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class Product : ContentBase
    {
        [NotNull] 
        public virtual string ShortDescription { get; protected set; }

        public virtual decimal Price { get; protected set; }

        public virtual decimal? OldPrice { get; protected set; }

        public virtual decimal? SpecialPrice { get; protected set; }

        public virtual DateTime? SpecialPriceStart { get; protected set; }

        public virtual DateTime? SpecialPriceEnd { get; protected set; }
        
        public virtual bool HasOptions { get; set; }

        public virtual bool IsVisibleIndividually { get; set; }

        public virtual bool IsFeatured { get; set; }

        public virtual bool IsCallForPricing { get; set; }

        public virtual bool IsAllowToOrder { get; set; }
        
        public virtual bool StockTrackingIsEnabled { get; set; }
        
        public virtual string Sku { get; set; }

        public virtual string Gtin { get; set; }

        [Range(0, int.MaxValue)]
        public virtual int StockQuantity { get; protected set; }
        
        [Range(0, int.MaxValue)]
        public virtual int RestockThreshold { get; set; }

        [Range(0, int.MaxValue)]
        public virtual int MaxStockThreshold { get; set; }
        
        public virtual bool OnReorder { get; protected set; }

        [StringLength(450)] 
        public virtual string NormalizedName { get; protected set; }

        [Range(0, int.MaxValue)]
        public virtual int ReviewsCount { get; protected set; }

        [Range(1.0, 5.0)]
        public virtual double RatingAverage { get; protected set; }
        
        public virtual Guid? BrandId { get; protected set; }
        
        public virtual Guid? TaxClassId { get; protected set; }
        
        public virtual Guid ProductTemplateId { get; protected set; }

        public virtual Collection<ProductPicture> Pictures { get; protected set; }

        public virtual Collection<ProductLink> ProductLinks { get; protected set; }
        
        public virtual Collection<ProductAttributeValue> AttributeValues { get; protected set; }

        public virtual Collection<ProductOptionValue> OptionValues { get; protected set; }
        
        public virtual Collection<ProductOptionCombination> OptionCombinations { get; protected set; }

        public virtual Collection<ProductLink> LinkedProductLinks { get; protected set; }

        public virtual Collection<ProductCategory> ProductCategories { get; protected set; }

        public virtual Collection<ProductPriceHistory> PriceHistories { get; protected set; }
        
        public virtual Collection<ProductTag> Tags { get; protected set; }
        
        public virtual Collection<ProductVendor> Vendors { get; protected set; }


        protected Product()
        {

        }

        public Product(
            [NotNull] string name, 
            [NotNull] string slug,
            [NotNull] string shortDescription,
            [CanBeNull] string description,
            decimal price,
            Guid imageId,
            Guid productTemplateId) : base(name, slug, description)
        {
            Check.NotNullOrWhiteSpace(shortDescription, nameof(shortDescription));
            
            ShortDescription = shortDescription;
            Price = price;
            ImageId = imageId;
            ProductTemplateId = productTemplateId;
            
            Pictures = new Collection<ProductPicture>();
            ProductLinks = new Collection<ProductLink>();
            AttributeValues = new Collection<ProductAttributeValue>();
            OptionValues = new Collection<ProductOptionValue>();
            OptionCombinations = new Collection<ProductOptionCombination>();
            LinkedProductLinks = new Collection<ProductLink>();
            ProductCategories = new Collection<ProductCategory>();
            PriceHistories = new Collection<ProductPriceHistory>();
            Tags = new Collection<ProductTag>();
            Vendors = new Collection<ProductVendor>();
        }
        
        public virtual void SetShortDescription([NotNull] string shortDescription)
        {
            ShortDescription = Check.NotNullOrWhiteSpace(shortDescription, nameof(shortDescription));
        }
        
        public virtual void ChangePrice(decimal newPrice)
        {
            var priceHistory = new ProductPriceHistory(Id, Price);
            priceHistory.HasChangedPrice(newPrice);
            
            PriceHistories.Add(priceHistory);
            
            OldPrice = Price;
            Price = newPrice;
        }
        
        public virtual void SetSpecialPrice(decimal specialPrice, DateTime startDate, DateTime? endDate = null)
        {
            if (startDate < DateTime.Now)
            {
                throw new ArgumentException("Can not set start date in the past!", nameof(startDate));
            }

            if (endDate.HasValue && endDate <= startDate)
            {
                throw new ArgumentException("Can not set end date in the past of start date!", nameof(endDate));
            }

            var priceHistory = new ProductPriceHistory(Id, Price);
            priceHistory.HasSpecialPriceSet(specialPrice, startDate, endDate);

            SpecialPrice = specialPrice;
            SpecialPriceStart = startDate;
            SpecialPriceEnd = endDate;
        }

        public virtual void SetNormalizedName(string normalizedName = "")
        {
            if (string.IsNullOrWhiteSpace(normalizedName))
            {
                NormalizedName = Name.ToUpperInvariant();
                return;
            }

            NormalizedName = normalizedName;
        }

        public virtual void SetBrand(Guid brandId)
        {
            BrandId = brandId;
        }
        
        public virtual void SetTaxClass(Guid taxClassId)
        {
            TaxClassId = taxClassId;
        }

        public virtual void AddCategory(Guid categoryId)
        {
            if (ProductCategories.Any(x => x.CategoryId == categoryId))
            {
                ProductCategories.RemoveAll(x => x.CategoryId == categoryId);
            }

            ProductCategories.Add(new ProductCategory(Id, categoryId));
        }

        public virtual void AddMedia(Guid pictureId)
        {
            if (Pictures.Any(x => x.PictureId == pictureId))
            {
                Pictures.RemoveAll(x => x.PictureId == pictureId);
            }

            Pictures.Add(new ProductPicture(Id, pictureId));
        }
        
        public virtual void AddAttributeValue(Guid attributeValueId)
        {
            if (AttributeValues.Any(x => x.AttributeId == attributeValueId))
            {
                AttributeValues.RemoveAll(x => x.AttributeId == attributeValueId);
            }

            AttributeValues.Add(new ProductAttributeValue(Id, attributeValueId));
        }

        public virtual void AddOptionValue(Guid optionId)
        {
            if (OptionValues.Any(x => x.OptionId == optionId))
            {
                OptionValues.RemoveAll(x => x.OptionId == optionId);
            }

            OptionValues.Add(new ProductOptionValue(Id, optionId));
        }

        public virtual void AddOptionCombination(Guid optionId)
        {
            if (OptionCombinations.Any(x => x.OptionId == optionId))
            {
                OptionCombinations.RemoveAll(x => x.OptionId == optionId);
            }

            OptionCombinations.Add(new ProductOptionCombination(Id, optionId));
        }

        public virtual void AddTag(Guid tagId)
        {
            if (Tags.Any(x => x.TagId == tagId))
            {
                Tags.RemoveAll(x => x.TagId == tagId);
            }

            Tags.Add(new ProductTag(Id, tagId));
        }

        public virtual void AddProductLinks(Guid productLinkId,
            ProductLinkType productLinkType = ProductLinkType.Undefined)
        {
            if (ProductLinks.Any(x => x.LinkedProductId == productLinkId))
            {
                ProductLinks.RemoveAll(x => x.LinkedProductId == productLinkId);
            }

            ProductLinks.Add(new ProductLink(Id, productLinkId, productLinkType));
        }

        public virtual void UpdateRatingAverage(double newAverage)
        {
            var average = ((RatingAverage * ReviewsCount) + newAverage ) / (ReviewsCount + 1);
            RatingAverage = Math.Round(average * 2, MidpointRounding.AwayFromZero) / 2;
            
            IncreaseReviewsCount();
        }

        protected virtual void IncreaseReviewsCount()
        {
            ReviewsCount++;
        }

        public virtual bool HasSpecialPrice()
        {
            if (!SpecialPrice.HasValue)
            {
                return false;
            }

            if (SpecialPriceStart > DateTime.Now)
            {
                return false;
            }

            if (SpecialPriceEnd.HasValue && SpecialPriceEnd <= DateTime.Now)
            {
                return false;
            }

            return true;
        }
        
        public virtual int RemoveStock(int quantityDesired)
        {
            if (StockQuantity == 0)
            {
                throw new AbpException($"Empty stock, product item {Name} is sold out");
            }

            if (quantityDesired <= 0)
            {
                throw new AbpException("Item units desired should be greater than zero");
            }

            var removed = Math.Min(quantityDesired, StockQuantity);

            StockQuantity -= removed;

            return removed;
        }
        
        public virtual int AddStock(int quantity)
        {
            var original = StockQuantity;

            if (StockQuantity + quantity > MaxStockThreshold)
            {
                StockQuantity += MaxStockThreshold - StockQuantity;
            }
            else
            {
                StockQuantity += quantity;
            }

            OnReorder = false;

            return StockQuantity - original;
        }
    }
}
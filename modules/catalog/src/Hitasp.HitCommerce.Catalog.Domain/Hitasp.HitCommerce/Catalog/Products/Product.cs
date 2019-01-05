using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Hitasp.HitCommon.Models;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class Product : Content
    {
        [NotNull] 
        public virtual string ShortDescription { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual decimal Price { get; protected set; }

        public virtual decimal? OldPrice { get; protected set; }

        public virtual decimal? SpecialPrice { get; protected set; }

        public virtual DateTimeOffset? SpecialPriceStart { get; protected set; }

        public virtual DateTimeOffset? SpecialPriceEnd { get; protected set; }

        public virtual bool IsCallForPricing { get; set; }

        public virtual bool IsAllowToOrder { get; set; }
        
        public virtual bool StockTrackingIsEnabled { get; set; }

        public virtual int StockQuantity { get; protected set; }
        
        public virtual int RestockThreshold { get; set; }

        public virtual int MaxStockThreshold { get; set; }
        
        public virtual bool OnReorder { get; protected set; }

        [StringLength(450)] 
        public virtual string NormalizedName { get; protected set; }

        [Range(0, int.MaxValue)]
        public virtual int ReviewsCount { get; protected set; }

        [Range(1.0, 5.0)]
        public virtual double RatingAverage { get; protected set; }
        
        public virtual Guid? BrandId { get; set; }

        public virtual Guid? VendorId { get; set; }

        public virtual Guid ThumbnailImageId { get; set; }

        public virtual Collection<ProductMedia> Medias { get; protected set; }

        public virtual Collection<ProductLink> ProductLinks { get; protected set; }

        public virtual Collection<ProductLink> LinkedProductLinks { get; protected set; }

        public virtual Collection<ProductCategory> Categories { get; protected set; }

        public virtual Collection<ProductPriceHistory> PriceHistories { get; protected set; }


        protected Product()
        {
            Medias = new Collection<ProductMedia>();
            ProductLinks = new Collection<ProductLink>();
            LinkedProductLinks = new Collection<ProductLink>();
            Categories = new Collection<ProductCategory>();
            PriceHistories = new Collection<ProductPriceHistory>();
        }

        public Product(
            Guid id,
            [NotNull] string name, 
            [NotNull] string slug,
            [NotNull] string shortDescription,
            decimal price,
            Guid thumbnailImageId) : base(id, name, slug)
        {
            ShortDescription = Check.NotNullOrWhiteSpace(shortDescription, nameof(shortDescription));;
            Price = price;
            ThumbnailImageId = thumbnailImageId;
        }
        
        public virtual void SetShortDescription([NotNull] string shortDescription)
        {
            ShortDescription = Check.NotNullOrWhiteSpace(shortDescription, nameof(shortDescription));
        }
        
        public virtual void SetDescription(string description)
        {
            Description = description;
        }
        
        public virtual void ChangePrice(decimal newPrice)
        {
            var priceHistory = new ProductPriceHistory(Id, Price);
            priceHistory.HasChangedPrice(newPrice);
            
            PriceHistories.Add(priceHistory);
            
            OldPrice = Price;
            Price = newPrice;
        }
        
        public virtual void SetSpecialPrice(decimal specialPrice, DateTimeOffset startDate, DateTimeOffset? endDate = null)
        {
            if (startDate < DateTimeOffset.Now)
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

        public virtual void AddCategory(Guid categoryId)
        {
            if (Categories.Any(x => x.CategoryId == categoryId))
            {
                Categories.RemoveAll(x => x.CategoryId == categoryId);
            }

            Categories.Add(new ProductCategory(Id, categoryId));
        }

        public virtual void AddMedia(Guid mediaId)
        {
            if (Medias.Any(x => x.MediaId == mediaId))
            {
                Medias.RemoveAll(x => x.MediaId == mediaId);
            }

            Medias.Add(new ProductMedia(Id, mediaId));
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

        public virtual bool HasSpecialPrice()
        {
            if (!SpecialPrice.HasValue)
            {
                return false;
            }

            if (SpecialPriceStart > DateTimeOffset.Now)
            {
                return false;
            }

            if (SpecialPriceEnd.HasValue && SpecialPriceEnd <= DateTimeOffset.Now)
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
        
        public virtual void IncreaseReviewsCount()
        {
            ReviewsCount++;
        }

        public virtual void UpdateRatingAverage(double newAverage)
        {
            var average = ((RatingAverage * ReviewsCount) + newAverage ) / (ReviewsCount + 1);
            RatingAverage = Math.Round(average * 2, MidpointRounding.AwayFromZero) / 2;
            
            IncreaseReviewsCount();
        }
    }
}
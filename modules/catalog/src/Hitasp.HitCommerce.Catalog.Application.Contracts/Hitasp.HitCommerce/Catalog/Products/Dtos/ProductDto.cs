using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Products.Dtos
{
    public class ProductDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public string ShortDescription { get; set; }

        public string Description { get; set; }
        
        public decimal Price { get; set; }

        public decimal? OldPrice { get; set; }

        public decimal? SpecialPrice { get; set; }

        public DateTime? SpecialPriceStart { get; set; }

        public DateTime? SpecialPriceEnd { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }
        
        public string Sku { get; set; }

        public string Gtin { get; set; }
        
        public bool StockTrackingIsEnabled { get; set; }
        
        public string LanguageCode { get; set; }
        
        public int DisplayOrder { get; set; }

        public bool IsPublished { get; set; }
        
        public DateTime? PublishedOn { get; set; }
        
        public Guid? BrandId { get; set; }
        
        public Guid? TaxClassId { get; set; }

        public Guid ProductTemplateId { get; set; }

        public Guid PictureId { get; set; }
        
        public bool HasOptions { get; set; }

        public bool IsVisibleIndividually { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsCallForPricing { get; set; }

        public bool IsAllowToOrder { get; set; }
        
        public bool IsAllowCustomerEntersPrice { get; set; }

        public int? StockQuantity { get; set; }
    }
}
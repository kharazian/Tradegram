using System;
using System.ComponentModel.DataAnnotations;
using Hitasp.HitCommerce.Catalog.Dtos;

namespace Hitasp.HitCommerce.Catalog.Products.Dtos
{
    public class ProductCreateDto : ContentCreateOrUpdateDtoBase
    {
        [Required]
        [StringLength(450)]
        public string ShortDescription { get; set; }
        
        public Guid? BrandId { get; set; }
        
        public Guid? TaxId { get; set; }

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
using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Products.Dtos
{
    public class ProductDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string FullDescription { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }
        
        public Guid ProductTemplateId { get; set; }

        public string PictureThumbnailUrl { get; set; }

        public bool ShowOnHomePage { get; set; }

        public string ProductTags { get; set; }

        public string Code { get; set; }
        
        public string ManufacturerPartNumber { get; set; }

        public virtual string Gtin { get; set; }

    }
}
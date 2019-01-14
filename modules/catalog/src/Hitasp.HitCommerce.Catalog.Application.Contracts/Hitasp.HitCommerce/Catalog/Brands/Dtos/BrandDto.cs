using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Brands.Dtos
{
    public class BrandDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string PriceRanges { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }
        
        public int DisplayOrder { get; set; }

        public string LanguageCode { get; set; }

        public bool IsPublished { get; set; }

        public DateTime? PublishedOn { get; set; }

        public Guid BrandTemplateId { get; set; }

        public Guid PictureId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Catalog.Dtos
{
    public class ContentCreateOrUpdateDtoBase
    {
        [Required]
        [StringLength(450)]
        public string Name { get; set; }

        [Required]
        [StringLength(450)]
        public string Slug { get; set; }

        public string Description { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }
        
        public string LanguageCode { get; set; }
        
        public int DisplayOrder { get; set; }

        public bool IsPublished { get; set; }
    }
}
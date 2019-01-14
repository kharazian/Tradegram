using System;
using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Catalog.Categories.Dtos
{
    public class CategoryCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }

        public string Description { get; set; }

        public string MetaTitle { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }
        
        public string LanguageCode { get; set; }
        
        public int DisplayOrder { get; set; }

        public bool IsPublished { get; set; }
        
        public bool ShowOnHomePage { get; set; }

        public bool IncludeInTopMenu { get; set; }

        public DateTime? PublishedOn { get; set; }
        
        public Guid? ParentCategoryId { get; set; }
        
        public Guid CategoryTemplateId { get; set; }

        public Guid PictureId { get; set; }        
    }
}
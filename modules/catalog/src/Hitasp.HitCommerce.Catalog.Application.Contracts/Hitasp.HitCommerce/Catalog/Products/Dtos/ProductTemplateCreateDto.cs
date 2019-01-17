using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Catalog.Categories.Dtos
{
    public class CategoryTemplateCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ViewPath { get; set; }

        public int DisplayOrder { get; set; }
    }
}
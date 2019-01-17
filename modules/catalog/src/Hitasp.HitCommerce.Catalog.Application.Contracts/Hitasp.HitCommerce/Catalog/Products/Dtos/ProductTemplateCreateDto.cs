using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Catalog.Products.Dtos
{
    public class ProductTemplateCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ViewPath { get; set; }

        public int DisplayOrder { get; set; }
    }
}
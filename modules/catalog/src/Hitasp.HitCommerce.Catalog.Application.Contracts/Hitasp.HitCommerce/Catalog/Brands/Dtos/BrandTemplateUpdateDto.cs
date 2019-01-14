using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Catalog.Brands.Dtos
{
    public class BrandTemplateUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ViewPath { get; set; }

        public int DisplayOrder { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Catalog.Tagging.Dtos
{
    public class ProductTagCreateOrUpdateDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
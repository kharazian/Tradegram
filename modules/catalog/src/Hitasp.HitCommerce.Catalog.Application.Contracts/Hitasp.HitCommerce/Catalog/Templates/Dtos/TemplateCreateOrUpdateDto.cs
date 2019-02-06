using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Catalog.Templates.Dtos
{
    public class TemplateCreateOrUpdateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string ViewPath { get; set; }

        public int DisplayOrder { get; set; }
    }
}
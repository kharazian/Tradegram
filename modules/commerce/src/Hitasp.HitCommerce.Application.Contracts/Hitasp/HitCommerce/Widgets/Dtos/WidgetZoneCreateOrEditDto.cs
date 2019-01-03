using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Widgets.Dtos
{
    public class WidgetZoneCreateOrEditDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
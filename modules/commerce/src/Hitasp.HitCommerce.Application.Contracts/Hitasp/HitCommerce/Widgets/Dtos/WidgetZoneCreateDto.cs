using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Widgets.Dtos
{
    public class WidgetZoneCreateDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
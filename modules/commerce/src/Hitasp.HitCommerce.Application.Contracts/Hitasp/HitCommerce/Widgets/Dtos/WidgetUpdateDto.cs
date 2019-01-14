using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Widgets.Dtos
{
    public class WidgetUpdateDto
    {
        [Required]
        public string Name { get; set; }

        public string ViewComponentName { get; set; }

        public string CreateUrl { get; set; }

        public string EditUrl { get; set; }

        public bool IsPublished { get; set; }
    }
}
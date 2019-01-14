using System;
using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Widgets.Dtos
{
    public class WidgetInstanceUpdateDto
    {
        public Guid WidgetId { get; set; }

        public int WidgetZoneId { get; set; }
        
        [Required]
        public string Name { get; set; }

        public DateTime PublishStart { get; set; }

        public DateTime? PublishEnd { get; set; }

        public int DisplayOrder { get; set; }

        public string Data { get; set; }

        public string HtmlData { get; set; }
    }
}
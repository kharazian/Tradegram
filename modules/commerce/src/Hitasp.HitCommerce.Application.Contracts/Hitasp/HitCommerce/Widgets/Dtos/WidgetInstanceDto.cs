using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Widgets.Dtos
{
    public class WidgetInstanceDto : EntityDto<Guid>
    {
        public Guid WidgetId { get; set; }

        public int WidgetZoneId { get; set; }
        
        public string Name { get; set; }

        public DateTimeOffset? PublishStart { get; set; }

        public DateTimeOffset? PublishEnd { get; set; }

        public int DisplayOrder { get; set; }

        public string Data { get; set; }

        public string HtmlData { get; set; }
    }
}
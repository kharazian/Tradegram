using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Widgets.Dtos
{
    public class WidgetDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string ViewComponentName { get; set; }

        public string CreateUrl { get; set; }

        public string EditUrl { get; set; }

        public bool IsPublished { get; set; }
    }
}
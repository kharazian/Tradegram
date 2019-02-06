using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Templates.Dtos
{
    public class TemplateDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string ViewPath { get; set; }

        public int DisplayOrder { get; set; }
    }
}
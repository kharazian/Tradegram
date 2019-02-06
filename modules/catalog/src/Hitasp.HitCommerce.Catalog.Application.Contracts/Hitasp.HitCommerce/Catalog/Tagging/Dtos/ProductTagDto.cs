using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Tagging.Dtos
{
    public class ProductTagDto : FullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int UsageCount { get; set; }
    }
}
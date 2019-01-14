using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Brands.Dtos
{
    public class BrandTemplateDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string ViewPath { get; set; }

        public int DisplayOrder { get; set; }
    }
}
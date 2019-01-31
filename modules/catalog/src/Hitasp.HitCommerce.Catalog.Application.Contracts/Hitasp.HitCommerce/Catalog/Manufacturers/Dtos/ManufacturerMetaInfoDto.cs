using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Dtos
{
    public class ManufacturerMetaInfoDto : EntityDto<Guid>
    {
        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }
    }
}
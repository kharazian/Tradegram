using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Dtos
{
    public class ManufacturerInfoDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
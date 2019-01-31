using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Dtos
{
    public class ManufacturerPublishingInfoDto : EntityDto<Guid>
    {
        public bool Published { get; set; }

        public bool ShowOnHomePage { get; set; }

        public int DisplayOrder { get; set; }
    }
}
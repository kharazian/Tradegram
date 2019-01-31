using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Categories.Dtos
{
    public class CategoryPublishingInfoDto : EntityDto<Guid>
    {
        public bool Published { get; set; }

        public bool ShowOnHomePage { get; set; }

        public int DisplayOrder { get; set; }
    }
}
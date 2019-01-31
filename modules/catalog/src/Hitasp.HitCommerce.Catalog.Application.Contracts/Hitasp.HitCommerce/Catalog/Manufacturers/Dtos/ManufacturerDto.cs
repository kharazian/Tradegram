using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Dtos
{
    public class ManufacturerDto : FullAuditedEntityDto<Guid>
    {
        public Guid ManufacturerTemplateId { get; set; }

        public ManufacturerInfoDto ManufacturerInfo { get; set; }
        
        public ManufacturerMetaInfoDto ManufacturerMetaInfo { get; set; }
        
        public ManufacturerPageInfoDto ManufacturerPageInfo { get; set; }
        
        public ManufacturerPublishingInfoDto ManufacturerPublishingInfo { get; set; }
        
        public Guid? PictureId { get; set; }
        
        public IList<Guid> AppliedDiscounts { get; set; } = new List<Guid>();
    }
}
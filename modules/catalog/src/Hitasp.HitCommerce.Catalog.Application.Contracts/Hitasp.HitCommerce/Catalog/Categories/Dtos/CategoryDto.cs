using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Categories.Dtos
{
    public class CategoryDto : FullAuditedEntityDto<Guid>
    {
        public Guid CategoryTemplateId { get; set; }

        public CategoryInfoDto CategoryInfo { get; set; }
        
        public CategoryMetaInfoDto CategoryMetaInfo { get; set; }
        
        public CategoryPageInfoDto CategoryPageInfo { get; set; }
        
        public CategoryPublishingInfoDto CategoryPublishingInfo { get; set; }
        
        public Guid? PictureId { get; set; }
        
        public Guid? ParentCategoryId { get; set; }
        
        public IList<Guid> AppliedDiscounts { get; set; } = new List<Guid>();
    }
}
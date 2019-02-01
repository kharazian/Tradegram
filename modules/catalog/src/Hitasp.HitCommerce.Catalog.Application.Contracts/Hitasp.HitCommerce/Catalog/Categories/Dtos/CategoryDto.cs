using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Categories.Dtos
{
    public class CategoryDto : FullAuditedEntityDto<Guid>
    {
        public Guid CategoryTemplateId { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string MetaKeywords { get; set; }

        public string MetaDescription { get; set; }

        public string MetaTitle { get; set; }
        
        public int PageSize { get; set; }

        public bool IsAllowCustomersToSelectPageSize { get; set; }
        
        public string PageSizeOptions { get; set; }

        public bool Published { get; set; }

        public bool ShowOnHomePage { get; set; }

        public int DisplayOrder { get; set; }

        public Guid? PictureId { get; set; }
        
        public Guid? ParentCategoryId { get; set; }
        
        public IList<Guid> AppliedDiscounts { get; set; } = new List<Guid>();
    }
}
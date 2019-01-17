using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Categories.Dtos
{
    public class CategoryListItemDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public bool IncludeInTopMenu { get; set; }

        public bool IsPublished { get; set; }

        public Guid? ParentCategoryId { get; set; }
    }
}
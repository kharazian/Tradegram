using System;
using Hitasp.HitCommerce.Catalog.Dtos;

namespace Hitasp.HitCommerce.Catalog.Categories.Dtos
{
    public class CategoryCreateDto : ContentCreateOrUpdateDtoBase
    {
        public CategoryCreateDto()
        {
            IsPublished = true;
        }
        
        public bool ShowOnHomePage { get; set; }

        public bool IncludeInTopMenu { get; set; }
        
        public Guid? ParentCategoryId { get; set; }
        
        public Guid CategoryTemplateId { get; set; }

        public Guid PictureId { get; set; }        
    }
}
using System;
using Hitasp.HitCommerce.Catalog.Dtos;

namespace Hitasp.HitCommerce.Catalog.Categories.Dtos
{
    public class CategoryUpdateDto : ContentCreateOrUpdateDtoBase
    {
        public bool ShowOnHomePage { get; set; }

        public bool IncludeInTopMenu { get; set; }

        public Guid? ParentCategoryId { get; set; }
        
        public Guid CategoryTemplateId { get; set; }

        public Guid PictureId { get; set; }    
    }
}
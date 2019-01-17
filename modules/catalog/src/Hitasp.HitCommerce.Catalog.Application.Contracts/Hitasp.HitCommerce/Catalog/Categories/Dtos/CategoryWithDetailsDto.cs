using System.Collections.Generic;
using Hitasp.HitCommerce.Catalog.Dtos;

namespace Hitasp.HitCommerce.Catalog.Categories.Dtos
{
    public class CategoryWithDetailsDto
    {
        public CategoryDto Category { get; set; }
        
        public CategoryThumbnailDto ParentCategory { get; set; }
        
        public ThumbnailImageDto ThumbnailImage { get; set; }
        
        public CategoryTemplateDto CategoryTemplate { get; set; }
        
        public IList<CategoryThumbnailDto> Children { get; set; } = new List<CategoryThumbnailDto>();
    }
}
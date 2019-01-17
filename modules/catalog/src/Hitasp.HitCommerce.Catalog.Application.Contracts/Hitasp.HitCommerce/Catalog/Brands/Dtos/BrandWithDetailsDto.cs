using Hitasp.HitCommerce.Catalog.Dtos;

namespace Hitasp.HitCommerce.Catalog.Brands.Dtos
{
    public class BrandWithDetailDto
    {
        public BrandDto Brand { get; set; }
        
        public BrandTemplateDto BrandTemplate { get; set; }
        
        public ThumbnailImageDto ThumbnailImage { get; set; }
    }
}
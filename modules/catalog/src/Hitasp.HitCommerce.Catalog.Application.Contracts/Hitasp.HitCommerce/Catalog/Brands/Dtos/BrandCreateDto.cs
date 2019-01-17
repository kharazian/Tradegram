using System;
using Hitasp.HitCommerce.Catalog.Dtos;

namespace Hitasp.HitCommerce.Catalog.Brands.Dtos
{
    public class BrandCreateDto : ContentCreateOrUpdateDtoBase
    {
        public BrandCreateDto()
        {
            IsPublished = true;
        }
        
        public Guid BrandTemplateId { get; set; }

        public Guid PictureId { get; set; }
    }
}
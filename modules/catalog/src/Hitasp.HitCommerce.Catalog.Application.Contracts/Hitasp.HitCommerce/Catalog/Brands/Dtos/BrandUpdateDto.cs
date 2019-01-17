using System;
using Hitasp.HitCommerce.Catalog.Dtos;

namespace Hitasp.HitCommerce.Catalog.Brands.Dtos
{
    public class BrandUpdateDto : ContentCreateOrUpdateDtoBase
    {
        public Guid BrandTemplateId { get; set; }

        public Guid PictureId { get; set; }
    }
}
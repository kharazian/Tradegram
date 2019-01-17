using System;
using Hitasp.HitCommerce.Catalog.Dtos;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Categories.Dtos
{
    public class CategoryThumbnailDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public ThumbnailImageDto ThumbnailImage { get; set; }
    }
}
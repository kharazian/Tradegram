using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Products.Dtos
{
    public class ProductTemplateDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string ViewPath { get; set; }

        public int DisplayOrder { get; set; }
    }
}
using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Products.Dtos
{
    public class ProductTinyDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        
        public string IsFeatured { get; set; }
        
        public string DisplayOrder { get; set; }
        
        public string IsPublished { get; set; }
    }
}
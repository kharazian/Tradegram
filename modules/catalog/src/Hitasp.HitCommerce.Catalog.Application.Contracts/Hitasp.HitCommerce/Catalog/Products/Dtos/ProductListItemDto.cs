using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Products.Dtos
{
    public class ProductListItemDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public bool HasOptions { get; set; }

        public bool IsVisibleIndividually { get; set; }

        public bool IsPublished { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsCallForPricing { get; set; }

        public bool IsAllowToOrder { get; set; }
        
        public bool IsAllowCustomerEntersPrice { get; set; }

        public int? StockQuantity { get; set; }
    }
}
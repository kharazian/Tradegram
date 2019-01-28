using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Dtos
{
    public class BackInStockSubscriptionDto : CreationAuditedEntityDto<Guid>
    {
        public Guid ProductId { get; set; }
        
        public Guid CustomerId { get; set; }
    }
}
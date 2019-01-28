using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Dtos
{
    public class BackInStockSubscriptionGetListByProductIdInput : PagedAndSortedResultRequestDto
    {
        public Guid ProductId { get; set; }
    }
}
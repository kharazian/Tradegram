using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Dtos
{
    public class BackInStockSubscriptionGetListByCustomerIdInput : PagedAndSortedResultRequestDto
    {
        public Guid CustomerId { get; set; }
    }
}
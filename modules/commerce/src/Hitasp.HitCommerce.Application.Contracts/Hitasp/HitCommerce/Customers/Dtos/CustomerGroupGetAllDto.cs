using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Customers.Dtos
{
    public class CustomerGroupGetAllDto : PagedAndSortedResultRequestDto
    {
        public Guid CustomerId { get; set; }
        
        public string Filter { get; set; }
    }
}
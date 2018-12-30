using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Customers.Dtos
{
    public class CustomerAddressGetAllDto : PagedAndSortedResultRequestDto
    {
        public Guid CustomerId { get; set; }
        
        public string Filter { get; set; }
        
        public AddressType AddressType { get; set; }
    }
}
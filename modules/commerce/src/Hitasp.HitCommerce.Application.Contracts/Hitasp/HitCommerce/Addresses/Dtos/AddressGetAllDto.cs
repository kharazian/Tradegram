using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Addresses.Dtos
{
    public class CustomerAddressGetAllDto : PagedAndSortedResultRequestDto
    {
        public Guid CustomerId { get; set; }
        
        public string Filter { get; set; }
        
        public int AddressType { get; set; }
    }
}
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Customers.Dtos
{
    public class CustomerAddressGetAllDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        
        public AddressType AddressType { get; set; }
    }
}
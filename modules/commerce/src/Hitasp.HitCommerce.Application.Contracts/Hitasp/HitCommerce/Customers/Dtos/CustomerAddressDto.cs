using System;

namespace Hitasp.HitCommerce.Customers.Dtos
{
    public class CustomerAddressDto
    {
        public Guid CustomerId { get; set; }
        
        public Guid AddressId { get; set; }
        
        public string FullName { get; set; }
        
        public string Address { get; set; }
        
        public AddressType AddressType { get; set; }
    }
}
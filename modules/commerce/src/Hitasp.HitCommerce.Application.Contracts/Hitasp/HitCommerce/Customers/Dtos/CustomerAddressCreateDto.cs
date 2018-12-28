using System;
using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.Customers.Dtos
{
    public class CustomerAddressCreateDto
    {
        [Required]
        public string Phone { get; set; }

        [Required] 
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }
        
        public Guid CountryId { get; set; }

        public Guid StateOrProvinceId { get; set; }

        public Guid? DistrictId { get; set; }
        
        public AddressType AddressType { get; set; }
    }
}
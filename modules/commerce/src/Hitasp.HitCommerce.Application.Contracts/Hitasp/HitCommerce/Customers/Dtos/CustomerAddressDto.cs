using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Customers.Dtos
{
    public class CustomerAddressDto : EntityDto<Guid>
    {
        public string Phone { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
        
        public string City { get; set; }

        public string ZipCode { get; set; }

        public Guid CountryId { get; set; }

        public Guid StateOrProvinceId { get; set; }

        public Guid? DistrictId { get; set; }
    }
}
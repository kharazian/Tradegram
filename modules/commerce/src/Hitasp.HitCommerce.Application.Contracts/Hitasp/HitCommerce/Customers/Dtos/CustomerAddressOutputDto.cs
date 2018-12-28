namespace Hitasp.HitCommerce.Customers.Dtos
{
    public class CustomerAddressOutputDto
    {
        public CustomerAddressDto Address { get; set; }
        
        public string DistrictName { get; set; }

        public string StateOrProvinceName { get; set; }

        public string CountryName { get; set; }
        
        public bool IsDefaultShippingAddress { get; set; }

        public bool DisplayDistrict { get; set; }

        public bool DisplayZipCode { get; set; }

        public bool DisplayCity { get; set; }
    }
}
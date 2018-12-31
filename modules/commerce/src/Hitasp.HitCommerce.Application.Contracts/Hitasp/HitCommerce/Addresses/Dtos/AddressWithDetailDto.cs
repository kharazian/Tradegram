namespace Hitasp.HitCommerce.Addresses.Dtos
{
    public class AddressWithDetailDto
    {
        public AddressDto Address { get; set; }

        public string CountryName { get; set; }

        public string StateOrProvinceName { get; set; }

        public string DistrictName { get; set; }

        public bool DisplayCity { get; set; }
        
        public bool DisplayDistrict { get; set; }
        
        public bool DisplayZipCode { get; set; }
    }
}
namespace Hitasp.HitCommerce.Addresses.Dtos
{
    public class AddressForEditOutput
    {
        public AddressCreateOrEditDto Address { get; set; }
        
        public string CountryName { get; set; }

        public string StateOrProvinceName { get; set; }

        public string DistrictName { get; set; }

        public bool DisplayCity { get; set; }
        
        public bool DisplayDistrict { get; set; }
        
        public bool DisplayZipCode { get; set; }
    }
}
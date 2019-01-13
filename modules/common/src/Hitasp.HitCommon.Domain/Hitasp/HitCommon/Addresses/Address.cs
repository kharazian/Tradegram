using System.Linq;
using Volo.Abp.Domain.Values;

namespace Hitasp.HitCommon.Addresses
{
    public class Address : ValueObject<Address>
    {
        public string CountryCode { get; private set;}
        
        public string CountryName { get; private set;}
        
        public string Phone { get; private set;}

        public string AddressLine1 { get; private set;}

        public string AddressLine2 { get; private set;}

        public string City { get; private set;}

        public string ZipCode { get; private set;}
        
        public string PostalCode { get; private set;}

        public string RegionName { get; private set;}

        public string DistrictName { get; private set;}
        
        public string FirstName { get; private set;}

        public string LastName { get; private set;}
        
        public string Email { get; private set;}
        

        private Address()
        {
        }

        public Address(
            string countryCode,
            string countryName,
            string phone,
            string addressLine1,
            string addressLine2,
            string city,
            string zipCode,
            string postalCode,
            string regionName,
            string districtName,
            string firstName,
            string lastName,
            string email)
        {
            //TODO: validate inputs
            
            CountryCode = countryCode;
            CountryName = countryName;
            Phone = phone;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            City = city;
            ZipCode = zipCode;
            PostalCode = postalCode;
            RegionName = regionName;
            DistrictName = districtName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public override string ToString()
        {
            return string.Join(", ",
                new[] {FirstName, LastName, AddressLine1, DistrictName ?? AddressLine2, City, RegionName, PostalCode ?? ZipCode, CountryName}.Where(x =>
                    !string.IsNullOrWhiteSpace(x)));
        }
    }
}
using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Addresses
{
    public class Address : CreationAuditedAggregateRoot<Guid>
    {
        [NotNull] 
        public virtual string Phone { get; protected set; }

        [NotNull] 
        public virtual string AddressLine1 { get; protected set; }

        public virtual string AddressLine2 { get; protected set; }

        [NotNull] 
        public virtual string City { get; protected set; }

        [NotNull] 
        public virtual string ZipCode { get; protected set; }

        public virtual Guid CountryId { get; protected set; }

        public virtual Guid StateOrProvinceId { get; protected set; }

        public virtual Guid? DistrictId { get; protected set; }

        protected Address()
        {
        }

        public Address(
            Guid id,
            [NotNull] string phone,
            [NotNull] string addressLine1,
            [CanBeNull] string addressLine2,
            [NotNull] string city,
            [NotNull] string zipCode,
            Guid countryId,
            Guid stateOrProvinceId,
            Guid? districtId = null)
        {
            Id = id;
            Phone = Check.NotNullOrWhiteSpace(phone, nameof(phone));
            AddressLine1 = Check.NotNullOrWhiteSpace(addressLine1, nameof(addressLine1));
            AddressLine2 = addressLine2;
            City = Check.NotNullOrWhiteSpace(city, nameof(city));
            ZipCode = Check.NotNullOrWhiteSpace(zipCode, nameof(zipCode));
            DistrictId = districtId;
            StateOrProvinceId = stateOrProvinceId;
            CountryId = countryId;
        }

        public virtual void SetNewLine([NotNull] string phone,
            [NotNull] string addressLine1,
            [CanBeNull] string addressLine2,
            [NotNull] string city,
            [NotNull] string zipCode)
        {
            Phone = Check.NotNullOrWhiteSpace(phone, nameof(phone));
            AddressLine1 = Check.NotNullOrWhiteSpace(addressLine1, nameof(addressLine1));
            AddressLine2 = addressLine2;
            City = Check.NotNullOrWhiteSpace(city, nameof(city));
            ZipCode = Check.NotNullOrWhiteSpace(zipCode, nameof(zipCode));
        }

        public virtual void SetNewDirection(Guid countryId,
            Guid stateOrProvinceId,
            Guid? districtId = null)
        {
            DistrictId = districtId;
            StateOrProvinceId = stateOrProvinceId;
            CountryId = countryId;
        }

        public override string ToString()
        {
            var addressLine = !string.IsNullOrWhiteSpace(AddressLine2) 
                ? AddressLine1 + " / " + AddressLine2 
                : AddressLine1;
            return $"{addressLine}, {int.Parse(ZipCode)} {City}";

        }
    }
}
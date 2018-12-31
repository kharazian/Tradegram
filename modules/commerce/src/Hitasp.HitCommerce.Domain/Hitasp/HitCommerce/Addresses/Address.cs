using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Addresses
{
    public class Address : CreationAuditedAggregateRoot<Guid>
    {
        [NotNull] 
        public virtual string Phone { get; protected internal set; }

        [NotNull] 
        public virtual string AddressLine1 { get; protected internal set; }

        public virtual string AddressLine2 { get; protected internal set; }

        [NotNull] 
        public virtual string City { get; protected internal set; }

        [NotNull] 
        public virtual string ZipCode { get; protected internal set; }

        public virtual Guid CountryId { get; protected internal set; }

        public virtual Guid StateOrProvinceId { get; protected internal set; }

        public virtual Guid? DistrictId { get; protected internal set; }

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
    }
}
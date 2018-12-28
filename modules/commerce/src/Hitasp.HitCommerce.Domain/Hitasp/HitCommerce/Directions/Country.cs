using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Directions
{
    public class Country : AggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string Code3 { get; protected set; }

        public virtual bool IsBillingEnabled { get; set; }

        public virtual bool IsShippingEnabled { get; set; }

        public virtual bool IsCityEnabled { get; set; }

        public virtual bool IsZipCodeEnabled { get; set; }

        public virtual bool IsDistrictEnabled { get; set; }

        protected Country()
        {
        }

        public Country(Guid id, [NotNull] string name, [NotNull] string code3)
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Code3 = Check.NotNullOrWhiteSpace(code3, nameof(code3));

            IsCityEnabled = true;
            IsZipCodeEnabled = true;
            IsDistrictEnabled = true;
        }
    }
}

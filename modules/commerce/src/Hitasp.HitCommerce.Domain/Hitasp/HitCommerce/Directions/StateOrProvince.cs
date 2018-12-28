using System;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Directions
{
    public class StateOrProvince : AggregateRoot<Guid>
    {
        public virtual Guid CountryId { get; protected set; }

        public virtual string Code { get; set; }

        [NotNull]
        public virtual string Name { get; protected set; }

        public virtual string Type { get; set; }

        protected StateOrProvince()
        {
        }

        public StateOrProvince(Guid id, Guid countryId, [NotNull] string name)
        {
            Id = id;
            CountryId = countryId;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }
    }
}

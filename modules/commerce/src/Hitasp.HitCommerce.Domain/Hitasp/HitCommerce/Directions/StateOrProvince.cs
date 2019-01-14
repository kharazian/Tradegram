using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Directions
{
    public class StateOrProvince : AggregateRoot<Guid>
    {
        public virtual Guid CountryId { get; protected set; }

        [NotNull]
        public virtual string Name { get; protected set; }
        
        public virtual string Code { get; set; }

        public virtual string Type { get; set; }

        protected StateOrProvince()
        {
        }

        public StateOrProvince(Guid countryId, [NotNull] string name)
        {
            CountryId = countryId;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }
        
        public virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }
    }
}

using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Directions
{
    public class District : AggregateRoot<Guid>
    {
        public virtual Guid StateOrProvinceId { get; protected set; }

        [NotNull]
        public virtual string Name { get; protected set; }

        public virtual string Type { get; set; }

        public virtual string Location { get; set; }

        protected District()
        {
        }

        public District(Guid stateOrProvinceId, [NotNull] string name)
        {
            StateOrProvinceId = stateOrProvinceId;
            Name = Check.NotNullOrWhiteSpace(name , nameof(name));
        }
        
        public virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }
    }
}

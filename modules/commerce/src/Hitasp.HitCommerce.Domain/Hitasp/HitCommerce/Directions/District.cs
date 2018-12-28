using System;
using System.ComponentModel.DataAnnotations;
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

        public District(Guid id, Guid stateOrProvinceId, [NotNull] string name)
        {
            Id = id;
            StateOrProvinceId = stateOrProvinceId;
            Name = Check.NotNullOrWhiteSpace(name , nameof(name));
        }
    }
}

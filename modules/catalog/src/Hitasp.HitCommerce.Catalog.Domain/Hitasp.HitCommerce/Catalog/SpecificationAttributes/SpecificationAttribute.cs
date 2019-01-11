using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.SpecificationAttributes
{
    public class SpecificationAttribute : AggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; protected set; }
        

        protected SpecificationAttribute()
        {
        }

        public SpecificationAttribute([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;
        }
        
        public virtual void SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;
        }
    }
}
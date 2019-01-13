using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Optionality
{
    //TODO: Move to common module
    public class ContentOption : AggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        protected ContentOption()
        {
        }

        public ContentOption([NotNull] string name)
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

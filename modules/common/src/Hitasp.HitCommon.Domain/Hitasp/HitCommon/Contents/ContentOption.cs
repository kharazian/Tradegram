using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Contents
{
    public class ContentOption : AggregateRoot<Guid>
    {
        public virtual string EntityTypeId { get; private set; }
        
        public virtual string Name { get; protected set; }

        protected ContentOption()
        {
        }

        public ContentOption([NotNull] string entityTypeId, [NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(entityTypeId, nameof(entityTypeId));
            Check.NotNullOrWhiteSpace(name, nameof(name));

            EntityTypeId = entityTypeId;
            Name = name;
        }
        
        public virtual void SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;
        }
    }
}

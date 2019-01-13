using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Contents
{
    public class ContentAttribute : AggregateRoot<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual Guid ContentAttributeGroupId { get; protected set; }

        
        protected ContentAttribute()
        {
        }

        public ContentAttribute([NotNull] string name, Guid attributeGroupId)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;
            ContentAttributeGroupId = attributeGroupId;
        }
        
        public virtual void SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;
        }

        public virtual void SetAttributeGroup(Guid attributeGroupId)
        {
            ContentAttributeGroupId = attributeGroupId;
        }
    }
}

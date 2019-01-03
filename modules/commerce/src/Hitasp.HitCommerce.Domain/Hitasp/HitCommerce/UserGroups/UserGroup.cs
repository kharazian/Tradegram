using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;

namespace Hitasp.HitCommerce.UserGroups
{
    public class UserGroup : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string Description { get; protected set; }

        public virtual bool IsActive { get; protected set; }

        public UserGroup(Guid id, [NotNull] string name)
        {
            Id = id;
            Name = name;
        }

        public virtual void SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }
        
        public virtual void SetDescription(string description)
        {
            Description = Check.NotNullOrWhiteSpace(description, nameof(description));
        }

        public virtual void UpdateStatus(bool status = false)
        {
            IsActive = status;
        }
   
        public bool IsGroupOwner(Guid customerId)
        {
            Check.NotNull(customerId, nameof(customerId));

            return CreatorId == customerId;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities.Auditing;
using Hitasp.HitCommerce.Customers;
using Volo.Abp;

namespace Hitasp.HitCommerce.UserGroups
{
    public class UserGroup : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        public virtual string Description { get; protected set; }

        public virtual bool IsActive { get; protected set; }

        public virtual ICollection<CustomerUserGroup> Members { get; protected set; }

        protected UserGroup()
        {
        }

        public UserGroup(Guid id, [NotNull] string name)
        {
            Id = id;
            Name = name;
 
            Members = new Collection<CustomerUserGroup>();
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
        
        public virtual void AddMember(Guid customerId)
        {
            Check.NotNull(customerId, nameof(customerId));

            if (IsGroupMember(customerId))
            {
                return;
            }

            Members.Add(new CustomerUserGroup(Id, customerId));
        }

        public virtual void RemoveMember(Guid customerId)
        {
            Check.NotNull(customerId, nameof(customerId));

            if (!IsGroupMember(customerId))
            {
                return;
            }

            Members.RemoveAll(x => x.CustomerId == customerId);
        }
        
        public bool IsGroupOwner(Guid customerId)
        {
            Check.NotNull(customerId, nameof(customerId));

            return CreatorId == customerId;
        }

        public bool IsGroupMember(Guid customerId)
        {
            Check.NotNull(customerId, nameof(customerId));

            return Members.Any(r => r.CustomerId == customerId);
        }
    }
}
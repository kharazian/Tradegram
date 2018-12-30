using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public virtual string Description { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual ICollection<CustomerUserGroup> CustomerGroups { get; protected set; }

        protected UserGroup()
        {
        }

        public UserGroup(Guid id, [NotNull] string name)
        {
            Id = id;
            Name = name;
 
            CustomerGroups = new Collection<CustomerUserGroup>();
        }

        public virtual UserGroup SetName(string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));

            return this;
        }
    }
}
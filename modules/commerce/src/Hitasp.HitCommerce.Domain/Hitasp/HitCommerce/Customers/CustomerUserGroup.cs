using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Customers
{
    public class CustomerUserGroup : Entity
    {
        public virtual Guid CustomerId { get; protected set; }

        public virtual Guid UserGroupId { get; protected set; }

        protected CustomerUserGroup()
        {
            
        }

        public CustomerUserGroup(Guid customerId, Guid userGroupId)
        {
            CustomerId = customerId;
            UserGroupId = userGroupId;
        }

        public override object[] GetKeys()
        {
            return new object[]
            {
                CustomerId,
                UserGroupId
            };
        }
    }
}

using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Customers
{
    public class CustomerAddress : Entity
    {
        public virtual Guid CustomerId { get; protected set; }

        public virtual Guid AddressId { get; protected set; }

        public virtual AddressType AddressType { get; protected set; }

        public virtual DateTimeOffset? LastUsedOn { get; protected set; }

        protected CustomerAddress()
        {
        }

        public CustomerAddress(Guid customerId, Guid addressId, AddressType addressType)
        {
            CustomerId = customerId;
            AddressId = addressId;
            AddressType = addressType;
        }

        public override object[] GetKeys()
        {
            return new object[]
            {
                CustomerId,
                AddressId,
                AddressType
            };
        }

        public virtual void UpdateUsage()
        {
            LastUsedOn = DateTimeOffset.Now;
        }
    }
}
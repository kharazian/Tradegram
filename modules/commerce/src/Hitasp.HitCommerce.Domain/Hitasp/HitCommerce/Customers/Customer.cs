using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Users;

namespace Hitasp.HitCommerce.Customers
{
    public class Customer : AggregateRoot<Guid>, IUser
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual string UserName { get; protected set; }

        public virtual string Email { get; protected set; }

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual bool EmailConfirmed { get; protected set; }

        public virtual string PhoneNumber { get; protected set; }

        public virtual bool PhoneNumberConfirmed { get; protected set; }

        public virtual Guid? VendorId { get; set; }

        public virtual Guid? DefaultShippingAddressId { get; protected set; }

        public virtual Guid? DefaultBillingAddressId { get; protected set; }

        public virtual ICollection<CustomerAddress> Addresses { get; protected set; }
        
        public virtual ICollection<CustomerUserGroup> CustomerGroups { get; protected set; }
        
        protected Customer()
        {
            ExtraProperties = new Dictionary<string, object>();
        }

        public Customer(IUserData user)
        {
            Id = user.Id;
            Email = user.Email;
            Name = user.Name;
            Surname = user.Surname;
            EmailConfirmed = user.EmailConfirmed;
            PhoneNumber = user.PhoneNumber;
            PhoneNumberConfirmed = user.PhoneNumberConfirmed;
            UserName = user.UserName;
            TenantId = user.TenantId;

            CustomerGroups = new Collection<CustomerUserGroup>();
            Addresses = new Collection<CustomerAddress>();
            
            ExtraProperties = new Dictionary<string, object>();
        }
        
        public virtual void JoinGroup(Guid userGroupId)
        {
            Check.NotNull(userGroupId, nameof(userGroupId));

            if (IsInGroup(userGroupId))
            {
                return;
            }

            CustomerGroups.Add(new CustomerUserGroup(Id, userGroupId));
        }

        public virtual void LeaveGroup(Guid userGroupId)
        {
            Check.NotNull(userGroupId, nameof(userGroupId));

            if (!IsInGroup(userGroupId))
            {
                return;
            }

            CustomerGroups.RemoveAll(r => r.UserGroupId == userGroupId);
        }

        public virtual bool IsInGroup(Guid userGroupId)
        {
            Check.NotNull(userGroupId, nameof(userGroupId));

            return CustomerGroups.Any(r => r.UserGroupId == userGroupId);
        }

        public virtual void SetAddress(Guid addressId, AddressType addressType)
        {
            Check.NotNull(addressId, nameof(addressId));

            Addresses.RemoveAll(x => x.AddressId == addressId);
            
            Addresses.Add(new CustomerAddress(Id, addressId, addressType));
        }

        public virtual void SetDefaultBillingAddress(Guid addressId)
        {
            Check.NotNull(addressId, nameof(addressId));
            
            DefaultBillingAddressId = addressId;
        }
        
        public virtual void SetDefaultShippingAddress(Guid addressId)
        {
            Check.NotNull(addressId, nameof(addressId));
            
            DefaultShippingAddressId = addressId;
        }
    }
}
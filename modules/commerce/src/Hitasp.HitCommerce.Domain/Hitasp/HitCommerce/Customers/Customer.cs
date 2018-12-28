using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public virtual Guid? DefaultShippingAddressId { get; set; }

        public virtual Guid? DefaultBillingAddressId { get; set; }

        public virtual ICollection<CustomerAddress> Addresses { get; protected set; }
        
        public virtual ICollection<CustomerUserGroup> Groups { get; protected set; }
        
        protected Customer()
        {
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

            Groups = new Collection<CustomerUserGroup>();
            Addresses = new Collection<CustomerAddress>();
        }
    }
}
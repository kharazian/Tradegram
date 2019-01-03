using System;
using System.Collections.Generic;
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

            ExtraProperties = new Dictionary<string, object>();
        }
    }
}
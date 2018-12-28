using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace Hitasp.HitCommerce.Customers
{
    public class CustomerLookupService : UserLookupService<Customer, ICustomerRepository>, ICustomerLookupService
    {
        public CustomerLookupService(
            ICustomerRepository customerRepository,
            IUnitOfWorkManager unitOfWorkManager)
            : base(
                customerRepository,
                unitOfWorkManager)
        {
        }

        protected override Customer CreateUser(IUserData externalUser)
        {
            return new Customer(externalUser);
        }
    }
}
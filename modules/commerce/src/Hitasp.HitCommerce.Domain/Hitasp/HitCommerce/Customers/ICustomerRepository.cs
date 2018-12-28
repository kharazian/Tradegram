using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Users;

namespace Hitasp.HitCommerce.Customers
{
    public interface ICustomerRepository : IUserRepository<Customer>
    {
        Task<List<Customer>> ListByVendorId(Guid vendorId);

        Task<List<Customer>> GetCustomers(int maxCount, string filter, CancellationToken cancellationToken = default);
    }
}
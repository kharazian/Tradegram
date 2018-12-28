using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Customers
{
    public interface ICustomerAddressRepository : IBasicRepository<CustomerAddress>
    {
        Task<List<CustomerAddress>> ListByCustomerId(Guid customerId);
    }
}
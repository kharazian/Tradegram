using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hitasp.HitCommerce.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Customers
{
    public class EfCoreCustomerUserGroupRepository : EfCoreRepository<HitCommerceDbContext, CustomerUserGroup>,
        ICustomerUserGroupRepository
    {
        public EfCoreCustomerUserGroupRepository(IDbContextProvider<HitCommerceDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<List<CustomerUserGroup>> ListByCustomerId(Guid customerId)
        {
            return await DbSet.Where(x => x.CustomerId == customerId).ToListAsync();
        }
    }
}
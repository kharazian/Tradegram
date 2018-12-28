using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Hitasp.HitCommerce.MongoDB;

namespace Hitasp.HitCommerce.Customers
{
    public class MongoCustomerUserGroupRepository : MongoDbRepository<IHitCommerceMongoDbContext, CustomerUserGroup>,
        ICustomerUserGroupRepository
    {
        public MongoCustomerUserGroupRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<List<CustomerUserGroup>> ListByCustomerId(Guid customerId)
        {
            return await GetMongoQueryable().Where(x => x.CustomerId == customerId).ToListAsync();
        }
    }
}
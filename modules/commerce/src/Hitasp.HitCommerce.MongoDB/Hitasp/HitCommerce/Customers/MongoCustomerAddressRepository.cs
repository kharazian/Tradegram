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
    public class MongoCustomerAddressRepository : MongoDbRepository<IHitCommerceMongoDbContext, CustomerAddress>,
        ICustomerAddressRepository
    {
        public MongoCustomerAddressRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<List<CustomerAddress>> ListByCustomerId(Guid customerId)
        {
            return await GetMongoQueryable().Where(x => x.CustomerId == customerId).ToListAsync();
        }
    }
}
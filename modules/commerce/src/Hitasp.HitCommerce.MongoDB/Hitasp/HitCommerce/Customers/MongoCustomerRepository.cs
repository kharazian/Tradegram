using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.MongoDB;
using Volo.Abp.Users.MongoDB;
using Hitasp.HitCommerce.MongoDB;

namespace Hitasp.HitCommerce.Customers
{
    public class MongoCustomerRepository : MongoUserRepositoryBase<IHitCommerceMongoDbContext, Customer>,
        ICustomerRepository
    {
        public MongoCustomerRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }

        public async Task<List<Customer>> ListByVendorId(Guid vendorId)
        {
            return await GetMongoQueryable().Where(x => x.VendorId == vendorId).ToListAsync();
        }

        public async Task<List<Customer>> GetCustomers(int maxCount, string filter, CancellationToken cancellationToken)
        {
            var query = GetMongoQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                query = query.Where(x => x.UserName.Contains(filter));
            }

            return await query.Take(maxCount).ToListAsync(cancellationToken);
        }
    }
}
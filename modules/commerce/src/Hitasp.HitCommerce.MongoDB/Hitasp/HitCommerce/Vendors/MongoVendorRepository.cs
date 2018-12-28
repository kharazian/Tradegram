using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Hitasp.HitCommerce.MongoDB;


namespace Hitasp.HitCommerce.Vendors
{
    public class MongoVendorRepository: MongoDbRepository<IHitCommerceMongoDbContext, Vendor, Guid>,
        IVendorRepository

    {
        public MongoVendorRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<Vendor> GetByName(string name)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Vendor> GetBySlug(string slug)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Slug == slug);
        }

        public async Task<Vendor> GetByEmailAddress(string emailAddress)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Email == emailAddress);
        }

        public async Task<List<Vendor>> GetActives()
        {
            return await GetMongoQueryable().Where(x => x.IsActive).ToListAsync();
        }
    }
}
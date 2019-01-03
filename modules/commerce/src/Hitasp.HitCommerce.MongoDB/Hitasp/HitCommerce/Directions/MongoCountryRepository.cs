using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Hitasp.HitCommerce.MongoDB;

namespace Hitasp.HitCommerce.Directions
{
    public class MongoCountryRepository : MongoDbRepository<IHitCommerceMongoDbContext, Country, Guid>, ICountryRepository
    {
        public MongoCountryRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Country>> FindAllCountriesForBilling()
        {
            return await GetMongoQueryable().Where(x => x.IsBillingEnabled).ToListAsync();
        }

        public async Task<List<Country>> FindAllCountriesForShipping()
        {
            return await GetMongoQueryable().Where(x => x.IsShippingEnabled).ToListAsync();
        }
    }
}
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

        public async Task<List<Country>> GetAllCountriesForBilling()
        {
            return await GetMongoQueryable().Where(x => x.IsBillingEnabled).ToListAsync();
        }

        public async Task<List<Country>> GetAllCountriesForShipping()
        {
            return await GetMongoQueryable().Where(x => x.IsShippingEnabled).ToListAsync();
        }

        public async Task<Country> GetCountryByCode(string isoCode)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Code3 == isoCode);
        }
    }
}
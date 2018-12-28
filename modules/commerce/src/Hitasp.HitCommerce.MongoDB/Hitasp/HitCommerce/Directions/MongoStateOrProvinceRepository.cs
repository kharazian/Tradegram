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
    public class MongoStateOrProvinceRepository : MongoDbRepository<IHitCommerceMongoDbContext, StateOrProvince, Guid>,
        IStateOrProvinceRepository
    {
        public MongoStateOrProvinceRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<StateOrProvince>> GetAllByCountryId(Guid countryId)
        {
            return await GetMongoQueryable().Where(x => x.CountryId == countryId).ToListAsync();
        }

        public async Task<StateOrProvince> GetByName(string name)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
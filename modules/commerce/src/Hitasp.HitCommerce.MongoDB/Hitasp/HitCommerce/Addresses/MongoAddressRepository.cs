using System;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Hitasp.HitCommerce.MongoDB;

namespace Hitasp.HitCommerce.Addresses
{
    public class MongoAddressRepository: MongoDbRepository<IHitCommerceMongoDbContext, Address, Guid>, IAddressRepository
    {
        public MongoAddressRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<int> GetAddressTotalByCountryId(Guid countryId)
        {
            return await GetMongoQueryable().Where(x => x.CountryId == countryId).CountAsync();
        }

        public async Task<int> GetAddressTotalByStateOrProvinceId(Guid stateOrProvinceId)
        {
            return await GetMongoQueryable().Where(x => x.StateOrProvinceId == stateOrProvinceId).CountAsync();
        }

        public async Task<int> GetAddressTotalByDistrictId(Guid districtId)
        {
            return await GetMongoQueryable().Where(x => x.DistrictId.HasValue && x.DistrictId == districtId).CountAsync();
        }
    }
}
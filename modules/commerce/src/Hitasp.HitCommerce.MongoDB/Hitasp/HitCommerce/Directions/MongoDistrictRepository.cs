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
    public class MongoDistrictRepository : MongoDbRepository<IHitCommerceMongoDbContext, District, Guid>,
        IDistrictRepository
    {
        public MongoDistrictRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<District>> GetAllByStateOrProvinceId(Guid stateOrProvinceId)
        {
            return await GetMongoQueryable().Where(x => x.StateOrProvinceId == stateOrProvinceId).ToListAsync();
        }

        public async Task<District> GetByName(string name)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
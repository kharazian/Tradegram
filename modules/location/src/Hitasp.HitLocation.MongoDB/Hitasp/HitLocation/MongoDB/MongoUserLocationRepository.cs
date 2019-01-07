using System;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitLocation.MongoDB
{
    public class MongoUserLocationRepository : MongoDbRepository<IHitLocationMongoDbContext, UserLocation>,
        IUserLocationRepository
    {
        public MongoUserLocationRepository(IMongoDbContextProvider<IHitLocationMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<UserLocation> GetUserLocationAsync(Guid userId)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
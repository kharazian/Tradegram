using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;

namespace Hitasp.HitLocation.MongoDB
{
    public class MongoLocationsRepository : MongoDbRepository<IHitLocationMongoDbContext, Locations, string>,
        ILocationsRepository
    {
        public MongoLocationsRepository(IMongoDbContextProvider<IHitLocationMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Locations> GetAsync(int locationId)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.LocationId == locationId);
        }

        public async Task<List<Locations>> GetCurrentUserRegionsListAsync(double longitude, double latitude)
        {
            var point = GeoJson.Point(GeoJson.Geographic(longitude, latitude));
            var orderByDistanceQuery = new FilterDefinitionBuilder<Locations>().Near(x => x.Location, point);
            var withinAreaQuery = new FilterDefinitionBuilder<Locations>().GeoIntersects("Polygon", point);
            var filter = Builders<Locations>.Filter.And(orderByDistanceQuery, withinAreaQuery);

            return await Collection.Find(filter).ToListAsync();
        }
    }
}
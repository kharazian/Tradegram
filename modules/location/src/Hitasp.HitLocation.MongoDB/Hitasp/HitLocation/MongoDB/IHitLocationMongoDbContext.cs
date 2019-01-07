using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Hitasp.HitLocation.MongoDB
{
    [ConnectionStringName("HitLocation")]
    public interface IHitLocationMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<Locations> Locations { get; }
        
        IMongoCollection<UserLocation> UserLocations { get; }
    }
}
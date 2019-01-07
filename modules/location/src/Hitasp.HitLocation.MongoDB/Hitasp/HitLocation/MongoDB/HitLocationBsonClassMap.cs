using MongoDB.Bson.Serialization;
using Volo.Abp.Threading;

namespace Hitasp.HitLocation.MongoDB
{
    public static class HitLocationBsonClassMap
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                BsonClassMap.RegisterClassMap<Locations>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<UserLocation>(map =>
                {
                    map.AutoMap();
                });
            });
        }
    }
}
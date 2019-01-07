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
                //Register mappings here. Example:
                //BsonClassMap.RegisterClassMap<Question>(map =>
                //{
                //    map.AutoMap();
                //});
            });
        }
    }
}
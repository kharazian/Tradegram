using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Mapping;
using MongoDB.Bson.Serialization;
using Volo.Abp.Threading;

namespace Hitasp.HitCommerce.Catalog.Manufacturers
{
    public static class ManufacturersBsonClassMap
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                BsonClassMap.RegisterClassMap<Manufacturer>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ManufacturerDiscount>(map => { map.AutoMap(); });
            });
        }
    }
}
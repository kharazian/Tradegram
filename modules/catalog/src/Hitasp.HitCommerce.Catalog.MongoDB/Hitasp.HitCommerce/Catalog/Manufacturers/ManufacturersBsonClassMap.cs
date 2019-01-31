using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
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
                BsonClassMap.RegisterClassMap<ManufacturerInfo>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ManufacturerMetaInfo>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ManufacturerPageInfo>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<ManufacturerPublishingInfo>(map => { map.AutoMap(); });
            });
        }
    }
}
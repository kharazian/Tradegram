using MongoDB.Bson.Serialization;
using Volo.Abp.Threading;

namespace Hitasp.HitCommerce.Catalog.Attributes
{
    public static class AttributeBsonClassMap
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                BsonClassMap.RegisterClassMap<CatalogAttribute>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<PredefinedAttributeValue>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<SpecificationAttribute>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<SpecificationAttributeOption>(map => { map.AutoMap(); });
            });
        }
    }
}
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Aggregates;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Entities;
using MongoDB.Bson.Serialization;
using Volo.Abp.Threading;

namespace Hitasp.HitCommerce.Catalog.SpecificationAttributes
{
    public static class SpecificationAttributesBsonClassMap
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                BsonClassMap.RegisterClassMap<SpecificationAttribute>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<SpecificationAttributeOption>(map => { map.AutoMap(); });
            });
        }
    }
}
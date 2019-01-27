using Hitasp.HitCommerce.Catalog.Tagging.Aggregates;
using MongoDB.Bson.Serialization;
using Volo.Abp.Threading;

namespace Hitasp.HitCommerce.Catalog.Tagging
{
    public static class TaggingBsonClassMap
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                BsonClassMap.RegisterClassMap<ProductTag>(map => { map.AutoMap(); });
            });
        }
    }
}
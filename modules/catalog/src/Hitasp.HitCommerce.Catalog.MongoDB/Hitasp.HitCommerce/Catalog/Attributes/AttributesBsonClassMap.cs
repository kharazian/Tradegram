using Hitasp.HitCommerce.Catalog.Attributes.Entities;
using MongoDB.Bson.Serialization;
using Volo.Abp.Threading;

namespace Hitasp.HitCommerce.Catalog.Attributes
{
    public static class AttributesBsonClassMap
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                BsonClassMap.RegisterClassMap<ProductAttribute>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<PredefinedAttributeValue>(map => { map.AutoMap(); });
            });
        }
    }
}
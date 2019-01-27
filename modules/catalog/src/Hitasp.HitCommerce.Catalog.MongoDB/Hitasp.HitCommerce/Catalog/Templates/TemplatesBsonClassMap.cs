using Hitasp.HitCommerce.Catalog.Templates.Aggregates;
using MongoDB.Bson.Serialization;
using Volo.Abp.Threading;

namespace Hitasp.HitCommerce.Catalog.Templates
{
    public static class TemplatesBsonClassMap
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                BsonClassMap.RegisterClassMap<Template>(map => { map.AutoMap(); });
            });
        }
    }
}
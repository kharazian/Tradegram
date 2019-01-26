using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.Tagging;
using Hitasp.HitCommerce.Catalog.Templates;
using MongoDB.Bson.Serialization;
using Volo.Abp.Threading;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public static class CategoryBsonClassMap
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                BsonClassMap.RegisterClassMap<Category>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<CategoryInfo>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<CategoryMeta>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<CategoryPublishingInfo>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<Tag>(map => { map.AutoMap(); });
                BsonClassMap.RegisterClassMap<Template>(map => { map.AutoMap(); });
            });
        }
    }
}
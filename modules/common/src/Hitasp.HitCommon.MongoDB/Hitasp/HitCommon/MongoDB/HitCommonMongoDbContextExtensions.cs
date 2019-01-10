using System;
using Hitasp.HitCommon.Entities;
using Hitasp.HitCommon.Media;
using Hitasp.HitCommon.Seo;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.MongoDB
{
    public static class HitCommonMongoDbContextExtensions
    {
        public static void ConfigureHitCommon(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new HitCommonMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<Image>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Media_Images";
            });
            
            builder.Entity<UrlRecord>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "UrlRecords";
            });
            
            builder.Entity<EntityType>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "EntityTypes";
            });
        }
    }
}

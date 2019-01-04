using System;
using Hitasp.HitCommon.Medias;
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

            builder.Entity<Media>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Media";
            });
            
            builder.Entity<UrlRecord>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "UrlRecords";
            });
        }
    }
}

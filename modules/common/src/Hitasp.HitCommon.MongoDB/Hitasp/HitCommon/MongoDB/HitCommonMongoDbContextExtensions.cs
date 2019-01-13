using System;
using Hitasp.HitCommon.Contents;
using Hitasp.HitCommon.Entities;
using Hitasp.HitCommon.Media;
using Hitasp.HitCommon.Seo;
using Hitasp.HitCommon.Tagging;
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
            
            builder.Entity<ContentOption>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ContentOptions";
            });
            
            builder.Entity<ContentAttributeGroup>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ContentAttributeGroup";
            });
            
            builder.Entity<ContentAttribute>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ContentAttributes";
            });
            
            builder.Entity<Tag>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Tagging";
            });
        }
    }
}

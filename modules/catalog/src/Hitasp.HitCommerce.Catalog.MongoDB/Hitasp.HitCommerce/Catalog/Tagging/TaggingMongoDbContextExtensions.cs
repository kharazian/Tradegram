using System;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Hitasp.HitCommerce.Catalog.Tagging.Aggregates;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Tagging
{
    public static class TaggingMongoDbContextExtensions
    {
        public static void ConfigureTagging(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<ProductTag>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProductTags";
            });
        }
    }
}
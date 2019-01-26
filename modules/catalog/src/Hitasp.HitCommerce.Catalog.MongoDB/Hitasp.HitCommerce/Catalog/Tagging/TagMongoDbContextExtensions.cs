using System;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Tagging
{
    public static class TagMongoDbContextExtensions
    {
        public static void ConfigureTagging(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<Tag>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Tags";
            });
        }
    }
}
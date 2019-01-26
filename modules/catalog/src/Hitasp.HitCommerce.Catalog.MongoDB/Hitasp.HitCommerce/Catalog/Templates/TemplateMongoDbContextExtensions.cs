using System;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Templates
{
    public static class TemplateMongoDbContextExtensions
    {
        public static void ConfigureTemplates(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<Template>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ViewTemplates";
            });
        }
    }
}
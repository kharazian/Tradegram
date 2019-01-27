using System;
using Hitasp.HitCommerce.Catalog.Attributes.Entities;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Attributes
{
    public static class AttributesMongoDbContextExtensions
    {
        public static void ConfigureAttributes(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<ProductAttribute>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProductAttribute";
            });

            builder.Entity<PredefinedAttributeValue>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "PredefinedAttributeValues";
            });
        }
    }
}
using System;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Attributes
{
    public static class AttributeMongoDbContextExtensions
    {
        public static void ConfigureAttributes(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<CatalogAttribute>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "CatalogAttributes";
            });

            builder.Entity<PredefinedAttributeValue>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "PredefinedAttributeValues";
            });

            builder.Entity<SpecificationAttribute>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "SpecificationAttributes";
            });
            
            builder.Entity<SpecificationAttributeOption>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "SpecificationAttributeOptions";
            });
        }
    }
}
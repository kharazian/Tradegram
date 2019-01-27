using System;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Aggregates;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Entities;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.SpecificationAttributes
{
    public static class SpecificationAttributesMongoDbContextExtensions
    {
        public static void ConfigureSpecificationAttributes(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);


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
using System;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Mapping;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Manufacturers
{
    public static class ManufacturersMongoDbContextExtensions
    {
        public static void ConfigureManufacturers(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<Manufacturer>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Manufacturers";
            });
            
            builder.Entity<ManufacturerDiscount>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Manufacturers_ManufacturerDiscount";
            });
        }
    }
}
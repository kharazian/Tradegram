using System;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
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
            
            builder.Entity<ManufacturerInfo>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Manufacturers_Info";
            });
            
            builder.Entity<ManufacturerMetaInfo>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Manufacturers_Meta";
            });
            
            builder.Entity<ManufacturerPublishingInfo>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Manufacturers_PublishingInfo";
            });
            
            builder.Entity<ManufacturerDiscount>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Manufacturers_ManufacturerDiscount";
            });
        }
    }
}
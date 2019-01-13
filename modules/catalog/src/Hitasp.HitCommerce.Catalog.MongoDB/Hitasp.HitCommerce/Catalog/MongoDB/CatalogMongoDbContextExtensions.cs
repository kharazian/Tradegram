using System;
using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.MongoDB
{
    public static class CatalogMongoDbContextExtensions
    {
        public static void ConfigureCatalog(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);
            
            builder.Entity<Brand>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Brands";
            });
            
            builder.Entity<BrandTemplate>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "BrandTemplates";
            });
            
            builder.Entity<Category>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Categories";
            });
            
            builder.Entity<CategoryTemplate>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "CategoryTemplates";
            });
        }
    }
}
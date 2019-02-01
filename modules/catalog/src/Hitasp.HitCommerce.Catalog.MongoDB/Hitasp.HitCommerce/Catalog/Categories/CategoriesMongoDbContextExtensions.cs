using System;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Mapping;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public static class CategoriesMongoDbContextExtensions
    {
        public static void ConfigureCategories(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);

            builder.Entity<Category>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Categories";
            });
            
            builder.Entity<CategoryDiscount>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Categories_CategoryDiscount";
            });
        }
    }
}
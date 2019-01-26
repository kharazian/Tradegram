using System;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.Categories.Mapping;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public static class CategoryMongoDbContextExtensions
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
            
            builder.Entity<CategoryInfo>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Categories_Info";
            });
            
            builder.Entity<CategoryMeta>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Categories_Meta";
            });
            
            builder.Entity<CategoryPublishingInfo>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Categories_PublishingInfo";
            });
            
            builder.Entity<CategoryDiscount>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Categories_CategoryDiscount";
            });
        }
    }
}
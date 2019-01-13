using System;
using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
using Hitasp.HitCommerce.Catalog.Products;
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

            builder.Entity<ProductTemplate>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProductTemplates";
            });

            builder.Entity<Product>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products";
            });

            builder.Entity<ProductAttribute>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProductAttributes";
            });

            builder.Entity<ProductCategory>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProductCategories";
            });

            builder.Entity<ProductLink>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProductLinks";
            });

            builder.Entity<ProductOption>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProductOptions";
            });

            builder.Entity<ProductOptionCombination>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProductOptionCombinations";
            });

            builder.Entity<ProductPicture>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProductPictures";
            });

            builder.Entity<ProductPriceHistory>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProductPriceHistories";
            });

            builder.Entity<ProductTag>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProductTags";
            });

            builder.Entity<ProductTemplateAttribute>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProductTemplateAttributes";
            });

            builder.Entity<ProductVendor>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "ProductVendors";
            });
        }
    }
}
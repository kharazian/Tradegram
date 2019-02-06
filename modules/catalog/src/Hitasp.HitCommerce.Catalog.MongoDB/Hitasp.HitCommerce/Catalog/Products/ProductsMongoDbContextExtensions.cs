using System;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Entities;
using Hitasp.HitCommerce.Catalog.MongoDB;
using Hitasp.HitCommerce.Catalog.Products.Abstracts;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public static class ProductsMongoDbContextExtensions
    {
        public static void ConfigureProducts(
            this IMongoModelBuilder builder,
            Action<MongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CatalogMongoModelBuilderConfigurationOptions();

            optionsAction?.Invoke(options);
            
            builder.Entity<BackInStockSubscription>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "BackInStockSubscriptions";
            });
            
            builder.Entity<Product>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products";
            });

            builder.Entity<Downloadable>();
            
            builder.Entity<Servicable>();

            builder.Entity<Shippable>();
            
            builder.Entity<ProductBasePrice>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Product_BasePrice";
            });
            
            builder.Entity<ProductInventory>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Product_Inventory";
            });
            
            builder.Entity<ProductPricing>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Product_Pricing";
            });
            
            builder.Entity<ProductShipping>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Product_Shipping";
            });
            
            builder.Entity<ProductProductAttribute>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_Attributes";
            });

            builder.Entity<ProductAttributeCombination>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_AttributeCombinations";
            });

            builder.Entity<ProductCategory>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_ProductCategory";
            });

            builder.Entity<ProductManufacturer>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_ProductManufacturer";
            });

            builder.Entity<ProductPicture>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_ProductPicture";
            });

            builder.Entity<ProductSpecificationAttribute>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_ProductSpecificationAttribute";
            });

            builder.Entity<ProductProductTag>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_ProductTag";
            });

            builder.Entity<ProductDiscount>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_ProductDiscount";
            });
            
            builder.Entity<CrossSellProduct>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_CrossSellProduct";
            });
            
            builder.Entity<RelatedProduct>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_RelatedProduct";
            });
            
            builder.Entity<RequiredProduct>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_RequiredProduct";
            });
        }
    }
}
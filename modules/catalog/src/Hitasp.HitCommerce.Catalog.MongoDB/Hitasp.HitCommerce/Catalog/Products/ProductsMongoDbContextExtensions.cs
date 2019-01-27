using System;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Aggregates;
using Hitasp.HitCommerce.Catalog.MongoDB;
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

            builder.Entity<ProductCode>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_Code";
            });

            builder.Entity<ProductInfo>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_Info";
            });

            builder.Entity<ProductMeta>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_Meta";
            });

            builder.Entity<ProductPriceInfo>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_PriceInfo";
            });

            builder.Entity<ProductPublishingInfo>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_PublishingInfo";
            });

            builder.Entity<ProductOrderingInfo>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_OrderingInfo";
            });

            builder.Entity<ProductRate>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_Rate";
               });

            builder.Entity<ProductShippingInfo>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "Products_ShippingInfo";
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
        }
    }
}
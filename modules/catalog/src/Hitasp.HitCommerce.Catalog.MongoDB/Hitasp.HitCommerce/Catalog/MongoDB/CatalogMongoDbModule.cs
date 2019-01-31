using Hitasp.HitCommerce.Catalog.Attributes;
using Hitasp.HitCommerce.Catalog.Attributes.Entities;
using Hitasp.HitCommerce.Catalog.Attributes.Repositories;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Entities;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Repositories;
using Hitasp.HitCommerce.Catalog.Categories;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.Categories.Mapping;
using Hitasp.HitCommerce.Catalog.Categories.Repositories;
using Hitasp.HitCommerce.Catalog.Manufacturers;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Hitasp.HitCommerce.Catalog.Manufacturers.Mapping;
using Hitasp.HitCommerce.Catalog.Manufacturers.Repositories;
using Hitasp.HitCommerce.Catalog.Products;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Hitasp.HitCommerce.Catalog.Products.Repositories;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Entities;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Repositories;
using Hitasp.HitCommerce.Catalog.Tagging;
using Hitasp.HitCommerce.Catalog.Tagging.Aggregates;
using Hitasp.HitCommerce.Catalog.Tagging.Repositories;
using Hitasp.HitCommerce.Catalog.Templates;
using Hitasp.HitCommerce.Catalog.Templates.Aggregates;
using Hitasp.HitCommerce.Catalog.Templates.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.MongoDB
{
    [DependsOn(
        typeof(CatalogDomainModule),
        typeof(AbpMongoDbModule)
    )]
    public class CatalogMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            AttributesBsonClassMap.Configure();
            BackInStockSubscriptionsBsonClassMap.Configure();
            CategoriesBsonClassMap.Configure();
            ManufacturersBsonClassMap.Configure();
            ProductsBsonClassMap.Configure();
            SpecificationAttributesBsonClassMap.Configure();
            TaggingBsonClassMap.Configure();
            TemplatesBsonClassMap.Configure();

            context.Services.AddMongoDbContext<CatalogMongoDbContext>(options =>
            {
                //Attributes
                options.AddRepository<ProductAttribute, MongoProductAttributeRepository>();
                options.AddRepository<PredefinedAttributeValue, MongoPredefinedAttributeValueRepository>();

                //BackInStockSubscriptions
                options.AddRepository<BackInStockSubscription, MongoBackInStockSubscriptionRepository>();

                //Categories
                options.AddRepository<Category, MongoCategoryRepository>();
                options.AddRepository<CategoryInfo, MongoCategoryInfoRepository>();
                options.AddRepository<CategoryMetaInfo, MongoCategoryMetaInfoRepository>();
                options.AddRepository<CategoryPageInfo, MongoCategoryPageInfoRepository>();
                options.AddRepository<CategoryPublishingInfo, MongoCategoryPublishingInfoRepository>();
                options.AddRepository<CategoryDiscount, MongoCategoryDiscountRepository>();

                //Manufacturers
                options.AddRepository<Manufacturer, MongoManufacturerRepository>();
                options.AddRepository<ManufacturerInfo, MongoManufacturerInfoRepository>();
                options.AddRepository<ManufacturerMetaInfo, MongoManufacturerMetaInfoRepository>();
                options.AddRepository<ManufacturerPageInfo, MongoManufacturerPageInfoRepository>();
                options.AddRepository<ManufacturerPublishingInfo, MongoManufacturerPublishingInfoRepository>();
                options.AddRepository<ManufacturerDiscount, MongoManufacturerDiscountRepository>();

                //Products
                options.AddRepository<Product, MongoProductRepository>();
                options.AddRepository<ProductAttributeCombination, MongoProductAttributeCombinationRepository>();
                options.AddRepository<ProductAttributeValue, MongoProductAttributeValueRepository>();
                options.AddRepository<ProductCode, MongoProductCodeRepository>();
                options.AddRepository<ProductInfo, MongoProductInfoRepository>();
                options.AddRepository<ProductMetaInfo, MongoProductMetaRepository>();
                options.AddRepository<ProductOrderingInfo, MongoProductOrderingInfoRepository>();
                options.AddRepository<ProductPriceInfo, MongoProductPriceInfoRepository>();
                options.AddRepository<ProductProductAttribute, MongoProductProductAttributeRepository>();
                options.AddRepository<ProductPublishingInfo, MongoProductPublishingInfoRepository>();
                options.AddRepository<ProductRate, MongoProductRateRepository>();
                options.AddRepository<ProductShippingInfo, MongoProductShippingInfoRepository>();
                options.AddRepository<StockQuantityHistory, MongoStockQuantityHistoryRepository>();
                options.AddRepository<CrossSellProduct, MongoCrossSellProductRepository>();
                options.AddRepository<ProductCategory, MongoProductCategoryRepository>();
                options.AddRepository<ProductDiscount, MongoProductDiscountRepository>();
                options.AddRepository<ProductManufacturer, MongoProductManufacturerRepository>();
                options.AddRepository<ProductPicture, MongoProductPictureRepository>();
                options.AddRepository<ProductProductTag, MongoProductProductTagRepository>();
                options.AddRepository<ProductSpecificationAttribute, MongoProductSpecificationAttributeRepository>();
                options.AddRepository<ProductWarehouseInventory, MongoProductWarehouseInventoryRepository>();
                options.AddRepository<RelatedProduct, MongoRelatedProductRepository>();

                //SpecificationAttributes
                options.AddRepository<SpecificationAttribute, MongoSpecificationAttributeRepository>();
                options.AddRepository<SpecificationAttributeOption, MongoSpecificationAttributeOptionRepository>();

                //Tagging
                options.AddRepository<ProductTag, MongoProductTagRepository>();

                //Templates
                options.AddRepository<Template, MongoTemplateRepository>();
            });
        }
    }
}
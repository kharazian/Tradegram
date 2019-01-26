using Hitasp.HitCommerce.Catalog.Attributes;
using Hitasp.HitCommerce.Catalog.Attributes.Repositories;
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
using Hitasp.HitCommerce.Catalog.Tagging;
using Hitasp.HitCommerce.Catalog.Templates;
using Hitasp.HitCommon.MongoDB;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.MongoDB
{
    [DependsOn(
        typeof(CatalogDomainModule),
        typeof(HitCommonMongoDbModule),
        typeof(AbpMongoDbModule)
    )]
    public class CatalogMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            AttributeBsonClassMap.Configure();
            TemplateBsonClassMap.Configure();
            TagBsonClassMap.Configure();
            CategoryBsonClassMap.Configure();
            ManufacturerBsonClassMap.Configure();
            ProductBsonClassMap.Configure();

            context.Services.AddMongoDbContext<CatalogMongoDbContext>(options =>
            {
                options.AddRepository<CatalogAttribute, MongoCatalogAttributeRepository>();
                options.AddRepository<PredefinedAttributeValue, MongoPredefinedAttributeValueRepository>();
                options.AddRepository<SpecificationAttribute, MongoSpecificationAttributeRepository>();
                options.AddRepository<SpecificationAttributeOption, MongoSpecificationAttributeOptionRepository>();
                
                options.AddRepository<Manufacturer, MongoManufacturerRepository>();
                options.AddRepository<ManufacturerInfo, MongoManufacturerInfoRepository>();
                options.AddRepository<ManufacturerMeta, MongoManufacturerMetaRepository>();
                options.AddRepository<ManufacturerPublishingInfo, MongoManufacturerPublishingInfoRepository>();
                options.AddRepository<ManufacturerDiscount, MongoManufacturerDiscountRepository>();

                options.AddRepository<Category, MongoCategoryRepository>();
                options.AddRepository<CategoryInfo, MongoCategoryInfoRepository>();
                options.AddRepository<CategoryMeta, MongoCategoryMetaRepository>();
                options.AddRepository<CategoryPublishingInfo, MongoCategoryPublishingInfoRepository>();
                options.AddRepository<CategoryDiscount, MongoCategoryDiscountRepository>();
                
                options.AddRepository<Product, MongoProductRepository>();
                options.AddRepository<CrossSellProduct, MongoCrossSellProductRepository>();
                options.AddRepository<ProductAttributeCombination, MongoProductAttributeCombinationRepository>();
                options.AddRepository<ProductAttribute, MongoProductAttributeRepository>();
                options.AddRepository<ProductAttributeValue, MongoProductAttributeValueRepository>();
                options.AddRepository<ProductCategory, MongoProductCategoryRepository>();
                options.AddRepository<ProductCode, MongoProductCodeRepository>();
                options.AddRepository<ProductDiscount, MongoProductDiscountRepository>();
                options.AddRepository<ProductInfo, MongoProductInfoRepository>();
                options.AddRepository<ProductManufacturer, MongoProductManufacturerRepository>();
                options.AddRepository<ProductMeta, MongoProductMetaRepository>();
                options.AddRepository<ProductOrderingInfo, MongoProductOrderingInfoRepository>();
                options.AddRepository<ProductPicture, MongoProductPictureRepository>();
                options.AddRepository<ProductPriceInfo, MongoProductPriceInfoRepository>();
                options.AddRepository<ProductPublishingInfo, MongoProductPublishingInfoRepository>();
                options.AddRepository<ProductRate, MongoProductRateRepository>();
                options.AddRepository<ProductShippingInfo, MongoProductShippingInfoRepository>();
                options.AddRepository<ProductSpecificationAttribute, MongoProductSpecificationAttributeRepository>();
                options.AddRepository<ProductTag, MongoProductTagRepository>();
                options.AddRepository<ProductWarehouseInventory, MongoProductWarehouseInventoryRepository>();
                options.AddRepository<RelatedProduct, MongoRelatedProductRepository>();
                options.AddRepository<StockQuantityHistory, MongoStockQuantityHistoryRepository>();
            });
        }
    }
}
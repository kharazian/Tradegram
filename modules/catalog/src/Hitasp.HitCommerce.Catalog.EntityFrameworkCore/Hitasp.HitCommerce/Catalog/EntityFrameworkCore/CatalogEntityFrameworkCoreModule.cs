using Hitasp.HitCommerce.Catalog.Attributes;
using Hitasp.HitCommerce.Catalog.Attributes.Repositories;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.Categories.Mapping;
using Hitasp.HitCommerce.Catalog.Categories.Repositories;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Hitasp.HitCommerce.Catalog.Manufacturers.Mapping;
using Hitasp.HitCommerce.Catalog.Manufacturers.Repositories;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Hitasp.HitCommerce.Catalog.Products.Repositories;
using Hitasp.HitCommon.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Catalog.EntityFrameworkCore
{
    [DependsOn(
        typeof(CatalogDomainModule),
        typeof(HitCommonEntityFrameworkCoreModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class CatalogEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CatalogDbContext>(options =>
            {
                options.AddRepository<CatalogAttribute, EfCoreCatalogAttributeRepository>();
                options.AddRepository<PredefinedAttributeValue, EfCorePredefinedAttributeValueRepository>();
                options.AddRepository<SpecificationAttribute, EfCoreSpecificationAttributeRepository>();
                options.AddRepository<SpecificationAttributeOption, EfCoreSpecificationAttributeOptionRepository>();

                options.AddRepository<Manufacturer, EfCoreManufacturerRepository>();
                options.AddRepository<ManufacturerInfo, EfCoreManufacturerInfoRepository>();
                options.AddRepository<ManufacturerMeta, EfCoreManufacturerMetaRepository>();
                options.AddRepository<ManufacturerPublishingInfo, EfCoreManufacturerPublishingInfoRepository>();
                options.AddRepository<ManufacturerDiscount, EfCoreManufacturerDiscountRepository>();

                options.AddRepository<Category, EfCoreCategoryRepository>();
                options.AddRepository<CategoryInfo, EfCoreCategoryInfoRepository>();
                options.AddRepository<CategoryMeta, EfCoreCategoryMetaRepository>();
                options.AddRepository<CategoryPublishingInfo, EfCoreCategoryPublishingInfoRepository>();
                options.AddRepository<CategoryDiscount, EfCoreCategoryDiscountRepository>();

                options.AddRepository<Product, EfCoreProductRepository>();
                options.AddRepository<CrossSellProduct, EfCoreCrossSellProductRepository>();
                options.AddRepository<ProductAttributeCombination, EfCoreProductAttributeCombinationRepository>();
                options.AddRepository<ProductAttribute, EfCoreProductAttributeRepository>();
                options.AddRepository<ProductAttributeValue, EfCoreProductAttributeValueRepository>();
                options.AddRepository<ProductCategory, EfCoreProductCategoryRepository>();
                options.AddRepository<ProductCode, EfCoreProductCodeRepository>();
                options.AddRepository<ProductDiscount, EfCoreProductDiscountRepository>();
                options.AddRepository<ProductInfo, EfCoreProductInfoRepository>();
                options.AddRepository<ProductManufacturer, EfCoreProductManufacturerRepository>();
                options.AddRepository<ProductMeta, EfCoreProductMetaRepository>();
                options.AddRepository<ProductOrderingInfo, EfCoreProductOrderingInfoRepository>();
                options.AddRepository<ProductPicture, EfCoreProductPictureRepository>();
                options.AddRepository<ProductPriceInfo, EfCoreProductPriceInfoRepository>();
                options.AddRepository<ProductPublishingInfo, EfCoreProductPublishingInfoRepository>();
                options.AddRepository<ProductRate, EfCoreProductRateRepository>();
                options.AddRepository<ProductShippingInfo, EfCoreProductShippingInfoRepository>();
                options.AddRepository<ProductSpecificationAttribute, EfCoreProductSpecificationAttributeRepository>();
                options.AddRepository<ProductTag, EfCoreProductTagRepository>();
                options.AddRepository<ProductWarehouseInventory, EfCoreProductWarehouseInventoryRepository>();
                options.AddRepository<RelatedProduct, EfCoreRelatedProductRepository>();
                options.AddRepository<StockQuantityHistory, EfCoreStockQuantityHistoryRepository>();
            });
        }
    }
}
using Hitasp.HitCommerce.Catalog.Attributes.Entities;
using Hitasp.HitCommerce.Catalog.Attributes.Repositories;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Entities;
using Hitasp.HitCommerce.Catalog.BackInStockSubscriptions.Repositories;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.Categories.Mapping;
using Hitasp.HitCommerce.Catalog.Categories.Repositories;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Mapping;
using Hitasp.HitCommerce.Catalog.Manufacturers.Repositories;
using Hitasp.HitCommerce.Catalog.Products.Abstracts;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Hitasp.HitCommerce.Catalog.Products.Repositories;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Entities;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Repositories;
using Hitasp.HitCommerce.Catalog.Tagging.Aggregates;
using Hitasp.HitCommerce.Catalog.Tagging.Repositories;
using Hitasp.HitCommerce.Catalog.Templates.Aggregates;
using Hitasp.HitCommerce.Catalog.Templates.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Catalog.EntityFrameworkCore
{
    [DependsOn(
        typeof(CatalogDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class CatalogEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CatalogDbContext>(options =>
            {
                //Attributes
                options.AddRepository<ProductAttribute, EfCoreProductAttributeRepository>();
                options.AddRepository<PredefinedAttributeValue, EfCorePredefinedAttributeValueRepository>();

                //BackInStockSubscriptions
                options.AddRepository<BackInStockSubscription, EfCoreBackInStockSubscriptionRepository>();

                //Categories
                options.AddRepository<Category, EfCoreCategoryRepository>();
                options.AddRepository<CategoryDiscount, EfCoreCategoryDiscountRepository>();

                //Manufacturers
                options.AddRepository<Manufacturer, EfCoreManufacturerRepository>();
                options.AddRepository<ManufacturerDiscount, EfCoreManufacturerDiscountRepository>();

                //Products
                options.AddRepository<Product, EfCoreProductRepository>();
                options.AddRepository<ProductAttributeCombination, EfCoreProductAttributeCombinationRepository>();
                options.AddRepository<ProductAttributeValue, EfCoreProductAttributeValueRepository>();
                options.AddRepository<ProductProductAttribute, EfCoreProductProductAttributeRepository>();
                options.AddRepository<StockQuantityHistory, EfCoreStockQuantityHistoryRepository>();
                options.AddRepository<CrossSellProduct, EfCoreCrossSellProductRepository>();
                options.AddRepository<ProductCategory, EfCoreProductCategoryRepository>();
                options.AddRepository<ProductDiscount, EfCoreProductDiscountRepository>();
                options.AddRepository<ProductManufacturer, EfCoreProductManufacturerRepository>();
                options.AddRepository<ProductPicture, EfCoreProductPictureRepository>();
                options.AddRepository<ProductProductTag, EfCoreProductProductTagRepository>();
                options.AddRepository<ProductSpecificationAttribute, EfCoreProductSpecificationAttributeRepository>();
                options.AddRepository<ProductWarehouseInventory, EfCoreProductWarehouseInventoryRepository>();
                options.AddRepository<RelatedProduct, EfCoreRelatedProductRepository>();

                //SpecificationAttributes
                options.AddRepository<SpecificationAttribute, EfCoreSpecificationAttributeRepository>();
                options.AddRepository<SpecificationAttributeOption, EfCoreSpecificationAttributeOptionRepository>();

                //Tagging
                options.AddRepository<ProductTag, EfCoreProductTagRepository>();

                //Templates
                options.AddRepository<Template, EfCoreTemplateRepository>();
            });
        }
    }
}
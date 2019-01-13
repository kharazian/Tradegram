using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
using Hitasp.HitCommerce.Catalog.Products;
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
            CatalogBsonClassMap.Configure();

            context.Services.AddMongoDbContext<CatalogMongoDbContext>(options =>
            {
                options.AddRepository<Brand, MongoBrandRepository>();
                options.AddRepository<BrandTemplate, MongoBrandTemplateRepository>();
                options.AddRepository<Category, MongoCategoryRepository>();
                options.AddRepository<CategoryTemplate, MongoCategoryTemplateRepository>();
                options.AddRepository<Product, MongoProductRepository>();
                options.AddRepository<ProductTemplate, MongoProductTemplateRepository>();
                options.AddRepository<ProductPriceHistory, MongoProductPriceHistoryRepository>();
                options.AddRepository<ProductAttribute, MongoProductAttributeRepository>();
                options.AddRepository<ProductCategory, MongoProductCategoryRepository>();
                options.AddRepository<ProductLink, MongoProductLinkRepository>();
                options.AddRepository<ProductOptionCombination, MongoProductOptionCombinationRepository>();
                options.AddRepository<ProductOption, MongoProductOptionRepository>();
                options.AddRepository<ProductPicture, MongoProductPictureRepository>();
                options.AddRepository<ProductTag, MongoProductTagRepository>();
                options.AddRepository<ProductTemplateAttribute, MongoProductTemplateAttributeRepository>();
                options.AddRepository<ProductVendor, MongoProductVendorRepository>();
            });
        }
    }
}
using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
using Hitasp.HitCommerce.Catalog.Products;
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
                options.AddRepository<Brand, EfCoreBrandRepository>();
                options.AddRepository<BrandTemplate, EfCoreBrandTemplateRepository>();
                options.AddRepository<Category, EfCoreCategoryRepository>();
                options.AddRepository<CategoryTemplate, EfCoreCategoryTemplateRepository>();
                options.AddRepository<Product, EfCoreProductRepository>();
                options.AddRepository<ProductTemplate, EfCoreProductTemplateRepository>();
                options.AddRepository<ProductPriceHistory, EfCoreProductPriceHistoryRepository>();
                options.AddRepository<ProductAttribute, EfCoreProductAttributeRepository>();
                options.AddRepository<ProductCategory, EfCoreProductCategoryRepository>();
                options.AddRepository<ProductLink, EfCoreProductLinkRepository>();
                options.AddRepository<ProductOptionCombination, EfCoreProductOptionCombinationRepository>();
                options.AddRepository<ProductOption, EfCoreProductOptionRepository>();
                options.AddRepository<ProductPicture, EfCoreProductPictureRepository>();
                options.AddRepository<ProductTag, EfCoreProductTagRepository>();
                options.AddRepository<ProductTemplateAttribute, EfCoreProductTemplateAttributeRepository>();
                options.AddRepository<ProductVendor, EfCoreProductVendorRepository>();
            });
        }
    }
}
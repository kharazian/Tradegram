using Hitasp.HitCommerce.Catalog.Brands;
using Hitasp.HitCommerce.Catalog.Categories;
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
            });
        }
    }
}
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace Hitasp.HitCommerce.Catalog
{
    [DependsOn(
        typeof(CatalogDomainModule),
        typeof(CatalogApplicationContractsModule),
        typeof(AbpAutoMapperModule)
        )]
    public class CatalogApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<CatalogApplicationAutoMapperProfile>(validate: true);
            });

            Configure<SettingOptions>(options =>
            {
                options.DefinitionProviders.Add<CatalogSettingDefinitionProvider>();
            });
        }
    }
}

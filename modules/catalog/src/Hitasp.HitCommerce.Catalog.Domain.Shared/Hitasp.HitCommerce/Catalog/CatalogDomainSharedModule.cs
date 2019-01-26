using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Hitasp.HitCommerce.Catalog.Localization;

namespace Hitasp.HitCommerce.Catalog
{
    [DependsOn(
        typeof(AbpLocalizationModule)
        )]
    public class CatalogDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<CatalogResource>("en");
            });
        }
    }
}

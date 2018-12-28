using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace Hitasp.HitCommerce
{
    [DependsOn(
        typeof(HitCommerceDomainModule),
        typeof(HitCommerceApplicationContractsModule),
        typeof(AbpAutoMapperModule)
        )]
    public class HitCommerceApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<HitCommerceApplicationAutoMapperProfile>(validate: true);
            });

            Configure<SettingOptions>(options =>
            {
                options.DefinitionProviders.Add<HitCommerceSettingDefinitionProvider>();
            });
        }
    }
}

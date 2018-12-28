using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Hitasp.HitCommerce.Localization;

namespace Hitasp.HitCommerce
{
    [DependsOn(
        typeof(AbpLocalizationModule)
        )]
    public class HitCommerceDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<HitCommerceResource>("en");
            });
        }
    }
}

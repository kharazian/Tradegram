using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Hitasp.HitLocation.Localization;

namespace Hitasp.HitLocation
{
    [DependsOn(
        typeof(AbpLocalizationModule)
        )]
    public class HitLocationDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<HitLocationResource>("en");
            });
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Hitasp.HitSocial.Localization;

namespace Hitasp.HitSocial
{
    [DependsOn(
        typeof(AbpLocalizationModule)
        )]
    public class HitSocialDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<HitSocialResource>("en");
            });
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace Hitasp.HitSocial
{
    [DependsOn(
        typeof(HitSocialDomainModule),
        typeof(HitSocialApplicationContractsModule),
        typeof(AbpAutoMapperModule)
        )]
    public class HitSocialApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<HitSocialApplicationAutoMapperProfile>(validate: true);
            });

            Configure<SettingOptions>(options =>
            {
                options.DefinitionProviders.Add<HitSocialSettingDefinitionProvider>();
            });
        }
    }
}

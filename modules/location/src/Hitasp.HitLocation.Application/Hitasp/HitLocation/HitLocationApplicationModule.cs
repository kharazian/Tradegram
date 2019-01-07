using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;

namespace Hitasp.HitLocation
{
    [DependsOn(
        typeof(HitLocationDomainModule),
        typeof(HitLocationApplicationContractsModule),
        typeof(AbpAutoMapperModule)
        )]
    public class HitLocationApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<HitLocationApplicationAutoMapperProfile>(validate: true);
            });

            Configure<SettingOptions>(options =>
            {
                options.DefinitionProviders.Add<HitLocationSettingDefinitionProvider>();
            });
        }
    }
}

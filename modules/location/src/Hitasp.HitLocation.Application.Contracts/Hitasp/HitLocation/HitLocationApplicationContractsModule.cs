using Microsoft.Extensions.DependencyInjection;
using Hitasp.HitLocation.Localization;
using Volo.Abp.Application;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Hitasp.HitLocation
{
    [DependsOn(
        typeof(HitLocationDomainSharedModule),
        typeof(AbpDddApplicationModule)
        )]
    public class HitLocationApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<PermissionOptions>(options =>
            {
                options.DefinitionProviders.Add<HitLocationPermissionDefinitionProvider>();
            });

            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<HitLocationApplicationContractsModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<HitLocationResource>()
                    .AddVirtualJson("/Hitasp/HitLocation/Localization/ApplicationContracts");
            });
        }
    }
}

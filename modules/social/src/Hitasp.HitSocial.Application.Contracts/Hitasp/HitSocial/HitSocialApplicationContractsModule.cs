using Microsoft.Extensions.DependencyInjection;
using Hitasp.HitSocial.Localization;
using Volo.Abp.Application;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Hitasp.HitSocial
{
    [DependsOn(
        typeof(HitSocialDomainSharedModule),
        typeof(AbpDddApplicationModule)
        )]
    public class HitSocialApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<PermissionOptions>(options =>
            {
                options.DefinitionProviders.Add<HitSocialPermissionDefinitionProvider>();
            });

            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<HitSocialApplicationContractsModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<HitSocialResource>()
                    .AddVirtualJson("/Hitasp/HitSocial/Localization/ApplicationContracts");
            });
        }
    }
}

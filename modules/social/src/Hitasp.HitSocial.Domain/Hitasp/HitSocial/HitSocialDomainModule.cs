using Microsoft.Extensions.DependencyInjection;
using Hitasp.HitSocial.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Hitasp.HitSocial
{
    [DependsOn(
        typeof(HitSocialDomainSharedModule)
        )]
    public class HitSocialDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<HitSocialDomainModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Get<HitSocialResource>().AddVirtualJson("/Hitasp/HitSocial/Localization/Domain");
            });

            Configure<ExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("HitSocial", typeof(HitSocialResource));
            });
        }
    }
}

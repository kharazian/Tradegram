using Hitasp.HitLocation.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Hitasp.HitLocation
{
    [DependsOn(
        typeof(HitLocationDomainSharedModule)
        )]
    public class HitLocationDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<HitLocationDomainModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Get<HitLocationResource>().AddVirtualJson("/Hitasp/HitLocation/Localization/Domain");
            });

            Configure<ExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("HitLocation", typeof(HitLocationResource));
            });
        }
    }
}

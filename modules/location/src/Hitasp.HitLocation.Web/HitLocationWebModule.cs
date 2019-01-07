using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Hitasp.HitLocation.Localization;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AutoMapper;
using Volo.Abp.Localization;
using Volo.Abp.Localization.Resources.AbpValidation;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Hitasp.HitLocation
{
    [DependsOn(typeof(HitLocationHttpApiModule))]
    [DependsOn(typeof(AbpAspNetCoreMvcUiThemeSharedModule))]
    [DependsOn(typeof(AbpAutoMapperModule))]
    public class HitLocationWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(typeof(HitLocationResource), typeof(HitLocationWebModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<NavigationOptions>(options =>
            {
                options.MenuContributors.Add(new HitLocationMenuContributor());
            });

            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<HitLocationWebModule>("Hitasp.HitLocation");
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<HitLocationResource>()
                    .AddBaseTypes(
                        typeof(AbpValidationResource),
                        typeof(AbpUiResource)
                    ).AddVirtualJson("/Localization/Resources/HitLocation");
            });

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<HitLocationWebAutoMapperProfile>(validate: true);
            });

            Configure<RazorPagesOptions>(options =>
            {
                //Configure authorization.
            });
        }
    }
}

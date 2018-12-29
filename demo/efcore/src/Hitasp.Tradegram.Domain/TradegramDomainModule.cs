using Microsoft.Extensions.DependencyInjection;
using Hitasp.Tradegram.Localization.Tradegram;
using Hitasp.Tradegram.Settings;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.Resources.AbpValidation;
using Volo.Abp.Modularity;
using Volo.Abp.Settings;
using Volo.Abp.VirtualFileSystem;

namespace Hitasp.Tradegram
{
    [DependsOn(
        typeof(AbpIdentityDomainModule),
        typeof(AbpAuditingModule),
        typeof(BackgroundJobsDomainModule),
        typeof(AbpAuditLoggingDomainModule)
        )]
    public class TradegramDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<TradegramDomainModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<TradegramResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/Tradegram");
            });

            Configure<SettingOptions>(options =>
            {
                options.DefinitionProviders.Add<TradegramSettingDefinitionProvider>();
            });
        }
    }
}

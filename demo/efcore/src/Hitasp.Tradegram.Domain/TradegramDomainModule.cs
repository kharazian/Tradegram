using Hitasp.Tradegram.Localization.Tradegram;
using Hitasp.Tradegram.Settings;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.Resources.AbpValidation;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.Settings;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;
using Volo.Blogging;
using Volo.Docs;

namespace Hitasp.Tradegram
{
    [DependsOn(
        typeof(AbpAuditLoggingDomainModule),
        typeof(BackgroundJobsDomainModule),
        typeof(AbpSettingManagementDomainModule),
        typeof(AbpTenantManagementDomainModule),
        typeof(AbpIdentityDomainModule),
        typeof(DocsDomainModule),
        typeof(BloggingDomainModule)
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

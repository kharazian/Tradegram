using Hitasp.Tradegram.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Blogging;
using Volo.Docs;
using Volo.Docs.Admin;

namespace Hitasp.Tradegram
{
    [DependsOn(
        typeof(TradegramDomainModule),
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpIdentityApplicationModule),
        typeof(DocsApplicationModule),
        typeof(DocsAdminApplicationModule),
        typeof(BloggingApplicationModule)
        )]
    public class TradegramApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<PermissionOptions>(options =>
            {
                options.DefinitionProviders.Add<TradegramPermissionDefinitionProvider>();
            });

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<TradegramApplicationAutoMapperProfile>();
            });
        }
    }
}

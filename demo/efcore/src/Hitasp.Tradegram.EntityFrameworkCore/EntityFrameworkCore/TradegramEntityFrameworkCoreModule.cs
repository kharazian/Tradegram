using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Blogging.EntityFrameworkCore;
using Volo.Docs.EntityFrameworkCore;

namespace Hitasp.Tradegram.EntityFrameworkCore
{
    [DependsOn(
        typeof(TradegramDomainModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(BackgroundJobsEntityFrameworkCoreModule),
        typeof(AbpAuditLoggingEntityFrameworkCoreModule),
        typeof(AbpPermissionManagementEntityFrameworkCoreModule),
        typeof(AbpSettingManagementEntityFrameworkCoreModule),
        typeof(AbpTenantManagementEntityFrameworkCoreModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(DocsEntityFrameworkCoreModule),
        typeof(BloggingEntityFrameworkCoreModule)
        )]
    public class TradegramEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<TradegramDbContext>(options =>
            {
                options.AddDefaultRepositories();
            });
        }
    }
}

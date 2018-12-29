using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.MongoDB;
using Volo.Abp.BackgroundJobs.MongoDB;
using Volo.Abp.Identity.MongoDB;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.MongoDB;
using Volo.Abp.SettingManagement.MongoDB;

namespace Hitasp.Tradegram.MongoDb
{
    [DependsOn(
        typeof(AbpPermissionManagementMongoDbModule),
        typeof(AbpSettingManagementMongoDbModule),
        typeof(AbpIdentityMongoDbModule),
        typeof(BackgroundJobsMongoDbModule),
        typeof(AbpAuditLoggingMongoDbModule)
        )]
    public class TradegramMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<TradegramMongoDbContext>(options =>
            {
                options.AddDefaultRepositories();
            });
        }
    }
}

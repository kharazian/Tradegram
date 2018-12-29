using Hitasp.Tradegram.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Hitasp.Tradegram
{
    [DependsOn(
        typeof(TradegramDomainModule),
        typeof(AbpIdentityApplicationModule))]
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

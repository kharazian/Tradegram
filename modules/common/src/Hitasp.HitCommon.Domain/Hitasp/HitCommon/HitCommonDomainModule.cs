using Volo.Abp.Modularity;
using Volo.Abp.Security;
using Volo.Abp.Settings;

namespace Hitasp.HitCommon
{
    [DependsOn(
        typeof(HitCommonDomainSharedModule),
        typeof(HitCommonAbstractionModule),
        typeof(AbpSecurityModule),
        typeof(AbpSettingsModule)
        )]
    public class HitCommonDomainModule : AbpModule
    {
        
    }
}

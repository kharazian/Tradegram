using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    [DependsOn(
        typeof(HitCommonDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class HitCommonEntityFrameworkCoreModule : AbpModule
    {
    }
}

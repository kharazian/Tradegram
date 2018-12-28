using Volo.Abp.EventBus;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommon
{
    [DependsOn(
        typeof(AbpEventBusModule)
        )]
    public class HitCommonAbstractionModule : AbpModule
    {
    }
}

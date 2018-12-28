using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.MongoDB
{
    [DependsOn(
        typeof(HitCommonDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class HitCommonMongoDbModule : AbpModule
    {
        
    }
}

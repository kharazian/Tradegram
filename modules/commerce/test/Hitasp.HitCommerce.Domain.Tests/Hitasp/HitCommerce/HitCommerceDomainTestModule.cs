using Hitasp.HitCommerce.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce
{
    [DependsOn(
        typeof(HitCommerceEntityFrameworkCoreTestModule)
        )]
    public class HitCommerceDomainTestModule : AbpModule
    {
        
    }
}

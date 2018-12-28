using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce
{
    [DependsOn(
        typeof(HitCommerceApplicationModule),
        typeof(HitCommerceDomainTestModule)
        )]
    public class HitCommerceApplicationTestModule : AbpModule
    {

    }
}

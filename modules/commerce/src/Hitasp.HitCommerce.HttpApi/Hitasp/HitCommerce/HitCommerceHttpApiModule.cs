using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce
{
    [DependsOn(
        typeof(HitCommerceApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class HitCommerceHttpApiModule : AbpModule
    {
        
    }
}

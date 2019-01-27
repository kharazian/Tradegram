using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Hitasp.HitSocial
{
    [DependsOn(
        typeof(HitSocialApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class HitSocialHttpApiModule : AbpModule
    {
        
    }
}

using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Hitasp.HitLocation
{
    [DependsOn(
        typeof(HitLocationApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class HitLocationHttpApiModule : AbpModule
    {
        
    }
}

using Hitasp.HitSocial.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitSocial
{
    [DependsOn(
        typeof(HitSocialEntityFrameworkCoreTestModule)
        )]
    public class HitSocialDomainTestModule : AbpModule
    {
        
    }
}

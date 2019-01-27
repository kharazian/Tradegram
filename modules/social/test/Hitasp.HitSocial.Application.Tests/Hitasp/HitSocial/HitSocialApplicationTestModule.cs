using Volo.Abp.Modularity;

namespace Hitasp.HitSocial
{
    [DependsOn(
        typeof(HitSocialApplicationModule),
        typeof(HitSocialDomainTestModule)
        )]
    public class HitSocialApplicationTestModule : AbpModule
    {

    }
}

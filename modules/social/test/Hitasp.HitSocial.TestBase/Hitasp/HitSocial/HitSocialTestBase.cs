using Volo.Abp;
using Volo.Abp.Modularity;

namespace Hitasp.HitSocial
{
    public abstract class HitSocialTestBase<TStartupModule> : AbpIntegratedTest<TStartupModule> 
        where TStartupModule : IAbpModule
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}

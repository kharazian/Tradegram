using Volo.Abp;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Catalog
{
    public abstract class CatalogTestBase<TStartupModule> : AbpIntegratedTest<TStartupModule> 
        where TStartupModule : IAbpModule
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}

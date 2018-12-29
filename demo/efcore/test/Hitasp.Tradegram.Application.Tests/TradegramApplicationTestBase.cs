using Volo.Abp;

namespace Hitasp.Tradegram
{
    public abstract class TradegramApplicationTestBase : AbpIntegratedTest<TradegramApplicationTestModule>
    {
        protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
        {
            options.UseAutofac();
        }
    }
}

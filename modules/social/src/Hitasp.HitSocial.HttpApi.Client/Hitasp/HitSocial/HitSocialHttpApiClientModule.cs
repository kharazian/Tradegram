using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitSocial
{
    [DependsOn(
        typeof(HitSocialApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class HitSocialHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "HitSocial";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(HitSocialApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitLocation
{
    [DependsOn(
        typeof(HitLocationApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class HitLocationHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "HitLocation";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(HitLocationApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}

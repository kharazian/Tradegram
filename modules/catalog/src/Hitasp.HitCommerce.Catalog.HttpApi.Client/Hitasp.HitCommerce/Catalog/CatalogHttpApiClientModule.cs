using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Catalog
{
    [DependsOn(
        typeof(CatalogApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class CatalogHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Catalog";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(CatalogApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}

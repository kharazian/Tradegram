using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Catalog
{
    [DependsOn(
        typeof(CatalogApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class CatalogHttpApiModule : AbpModule
    {
        
    }
}

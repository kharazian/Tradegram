using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Catalog
{
    [DependsOn(
        typeof(CatalogApplicationModule),
        typeof(CatalogDomainTestModule)
        )]
    public class CatalogApplicationTestModule : AbpModule
    {

    }
}

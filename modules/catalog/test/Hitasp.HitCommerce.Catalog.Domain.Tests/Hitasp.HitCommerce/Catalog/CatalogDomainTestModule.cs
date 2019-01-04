using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommerce.Catalog
{
    [DependsOn(
        typeof(CatalogEntityFrameworkCoreTestModule)
        )]
    public class CatalogDomainTestModule : AbpModule
    {
        
    }
}

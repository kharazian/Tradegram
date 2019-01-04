using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Hitasp.HitCommerce.Catalog
{
    public abstract class MyEntityRepository_Tests<TStartupModule> : CatalogTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        [Fact]
        public async Task Test1()
        {

        }
    }
}

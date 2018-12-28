using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Hitasp.HitCommerce
{
    public abstract class MyEntityRepository_Tests<TStartupModule> : HitCommerceTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        [Fact]
        public async Task Test1()
        {

        }
    }
}

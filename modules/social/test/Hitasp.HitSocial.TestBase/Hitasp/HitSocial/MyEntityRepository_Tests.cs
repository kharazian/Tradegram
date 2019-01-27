using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Hitasp.HitSocial
{
    public abstract class MyEntityRepository_Tests<TStartupModule> : HitSocialTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
        [Fact]
        public async Task Test1()
        {

        }
    }
}

using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace Hitasp.HitCommerce
{
    public class HitCommerceTestDataBuilder : ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private HitCommerceTestData _testData;

        public HitCommerceTestDataBuilder(
            IGuidGenerator guidGenerator,
            HitCommerceTestData testData)
        {
            _guidGenerator = guidGenerator;
            _testData = testData;
        }

        public void Build()
        {
            
        }
    }
}
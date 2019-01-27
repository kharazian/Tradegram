using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace Hitasp.HitSocial
{
    public class HitSocialTestDataBuilder : ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private HitSocialTestData _testData;

        public HitSocialTestDataBuilder(
            IGuidGenerator guidGenerator,
            HitSocialTestData testData)
        {
            _guidGenerator = guidGenerator;
            _testData = testData;
        }

        public void Build()
        {
            
        }
    }
}
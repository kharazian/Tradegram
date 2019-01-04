using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace Hitasp.HitCommerce.Catalog
{
    public class CatalogTestDataBuilder : ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private CatalogTestData _testData;

        public CatalogTestDataBuilder(
            IGuidGenerator guidGenerator,
            CatalogTestData testData)
        {
            _guidGenerator = guidGenerator;
            _testData = testData;
        }

        public void Build()
        {
            
        }
    }
}
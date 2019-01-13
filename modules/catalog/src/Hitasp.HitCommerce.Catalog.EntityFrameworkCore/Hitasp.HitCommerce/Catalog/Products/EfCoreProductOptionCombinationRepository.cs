using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class EfCoreProductOptionCombinationRepository : EfCoreRepository<ICatalogDbContext, ProductOptionCombination>,
        IProductOptionCombinationRepository
    {
        public EfCoreProductOptionCombinationRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
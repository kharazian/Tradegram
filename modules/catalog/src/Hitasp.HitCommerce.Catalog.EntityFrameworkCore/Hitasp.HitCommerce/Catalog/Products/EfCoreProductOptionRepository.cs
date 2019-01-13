using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class EfCoreProductOptionRepository : EfCoreRepository<ICatalogDbContext, ProductOption>,
        IProductOptionRepository
    {
        public EfCoreProductOptionRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
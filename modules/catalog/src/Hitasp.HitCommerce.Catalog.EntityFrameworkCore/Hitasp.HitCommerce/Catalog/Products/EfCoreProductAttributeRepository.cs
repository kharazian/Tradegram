using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class EfCoreProductAttributeRepository : EfCoreRepository<ICatalogDbContext, ProductAttribute>,
        IProductAttributeRepository
    {
        public EfCoreProductAttributeRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
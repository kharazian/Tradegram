using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class EfCoreProductVendorRepository : EfCoreRepository<ICatalogDbContext, ProductVendor>,
        IProductVendorRepository
    {
        public EfCoreProductVendorRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
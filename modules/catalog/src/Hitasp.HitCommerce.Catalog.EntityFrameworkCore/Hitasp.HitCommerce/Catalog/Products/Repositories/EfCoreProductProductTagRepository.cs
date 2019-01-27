using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public class EfCoreProductProductTagRepository : EfCoreRepository<ICatalogDbContext, ProductProductTag>,
        IProductProductTagRepository
    {
        public EfCoreProductProductTagRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
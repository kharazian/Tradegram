using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class EfCoreProductTemplateAttributeRepository : EfCoreRepository<ICatalogDbContext, ProductTemplateAttribute>,
        IProductTemplateAttributeRepository
    {
        public EfCoreProductTemplateAttributeRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
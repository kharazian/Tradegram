using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Attributes.Repositories
{
    public class EfCoreCatalogAttributeRepository : EfCoreRepository<ICatalogDbContext, CatalogAttribute, Guid>,
        ICatalogAttributeRepository
    {
        public EfCoreCatalogAttributeRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
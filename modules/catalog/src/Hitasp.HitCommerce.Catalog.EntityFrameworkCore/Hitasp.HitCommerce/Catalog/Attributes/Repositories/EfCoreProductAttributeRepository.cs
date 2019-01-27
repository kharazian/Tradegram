using System;
using Hitasp.HitCommerce.Catalog.Attributes.Entities;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Attributes.Repositories
{
    public class EfCoreProductAttributeRepository : EfCoreRepository<ICatalogDbContext, ProductAttribute, Guid>,
        IProductAttributeRepository
    {
        public EfCoreProductAttributeRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
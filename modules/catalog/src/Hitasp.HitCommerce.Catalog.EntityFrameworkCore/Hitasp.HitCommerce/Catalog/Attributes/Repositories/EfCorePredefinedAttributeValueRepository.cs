using System;
using Hitasp.HitCommerce.Catalog.Attributes.Entities;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Attributes.Repositories
{
    public class EfCorePredefinedAttributeValueRepository : EfCoreRepository<ICatalogDbContext, PredefinedAttributeValue, Guid>,
        IPredefinedAttributeValueRepository
    {
        public EfCorePredefinedAttributeValueRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
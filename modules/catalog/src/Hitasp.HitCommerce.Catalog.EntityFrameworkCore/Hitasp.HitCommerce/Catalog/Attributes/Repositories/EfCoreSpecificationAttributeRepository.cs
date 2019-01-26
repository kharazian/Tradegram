using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Attributes.Repositories
{
    public class EfCoreSpecificationAttributeRepository : EfCoreRepository<ICatalogDbContext, SpecificationAttribute, Guid>,
        ISpecificationAttributeRepository
    {
        public EfCoreSpecificationAttributeRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
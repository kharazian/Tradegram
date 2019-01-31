using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.SpecificationAttributes.Repositories
{
    public class EfCoreSpecificationAttributeRepository : EfCoreRepository<ICatalogDbContext, SpecificationAttribute, Guid>,
        ISpecificationAttributeRepository
    {
        public EfCoreSpecificationAttributeRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
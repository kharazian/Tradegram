using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.SpecificationAttributes.Repositories
{
    public class EfCoreSpecificationAttributeOptionRepository :
        EfCoreRepository<ICatalogDbContext, SpecificationAttributeOption, Guid>,
        ISpecificationAttributeOptionRepository
    {
        public EfCoreSpecificationAttributeOptionRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) :
            base(dbContextProvider)
        {
        }
    }
}
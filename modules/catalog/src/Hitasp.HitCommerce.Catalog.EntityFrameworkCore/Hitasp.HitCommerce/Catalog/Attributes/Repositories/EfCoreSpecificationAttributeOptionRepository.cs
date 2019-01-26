using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Attributes.Repositories
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
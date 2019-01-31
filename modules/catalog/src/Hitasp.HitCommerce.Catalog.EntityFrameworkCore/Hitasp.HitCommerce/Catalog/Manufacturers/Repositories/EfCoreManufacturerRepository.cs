using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Repositories
{
    public class EfCoreManufacturerRepository : EfCoreRepository<ICatalogDbContext, Manufacturer, Guid>,
        IManufacturerRepository
    {
        public EfCoreManufacturerRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
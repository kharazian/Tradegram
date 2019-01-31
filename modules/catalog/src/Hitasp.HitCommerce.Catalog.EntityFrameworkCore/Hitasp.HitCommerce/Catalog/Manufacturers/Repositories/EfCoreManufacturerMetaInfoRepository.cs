using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Repositories
{
    public class EfCoreManufacturerMetaInfoRepository : EfCoreRepository<ICatalogDbContext, ManufacturerMetaInfo, Guid>,
        IManufacturerMetaInfoRepository
    {
        public EfCoreManufacturerMetaInfoRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
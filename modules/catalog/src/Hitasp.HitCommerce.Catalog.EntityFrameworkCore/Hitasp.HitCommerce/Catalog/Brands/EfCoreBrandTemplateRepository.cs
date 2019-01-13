using System;
using Hitasp.HitCommerce.Catalog.Brands.Aggregates;
using Hitasp.HitCommerce.Catalog.Brands.Repositories;
using Hitasp.HitCommon.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public class EfCoreBrandTemplateRepository : EfCoreRepository<IHitCommonDbContext, BrandTemplate, Guid>, IBrandTemplateRepository
    {
        public EfCoreBrandTemplateRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
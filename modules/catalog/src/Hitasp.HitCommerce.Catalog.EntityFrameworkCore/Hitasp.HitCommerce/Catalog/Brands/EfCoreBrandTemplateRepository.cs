using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommon.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public class EfCoreBrandTemplateRepository : EfCoreRepository<ICatalogDbContext, BrandTemplate, Guid>, IBrandTemplateRepository
    {
        public EfCoreBrandTemplateRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
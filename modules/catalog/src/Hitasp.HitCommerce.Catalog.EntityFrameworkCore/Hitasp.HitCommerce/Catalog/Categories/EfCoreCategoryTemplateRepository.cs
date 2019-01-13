using System;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommon.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class EfCoreCategoryTemplateRepository : EfCoreRepository<ICatalogDbContext, CategoryTemplate, Guid>,
        ICategoryTemplateRepository
    {
        public EfCoreCategoryTemplateRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
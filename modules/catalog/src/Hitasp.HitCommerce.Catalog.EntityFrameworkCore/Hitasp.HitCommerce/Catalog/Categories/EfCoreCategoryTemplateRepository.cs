using System;
using Hitasp.HitCommon.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class EfCoreCategoryTemplateRepository : EfCoreRepository<IHitCommonDbContext, CategoryTemplate, Guid>,
        ICategoryTemplateRepository
    {
        public EfCoreCategoryTemplateRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }
    }
}
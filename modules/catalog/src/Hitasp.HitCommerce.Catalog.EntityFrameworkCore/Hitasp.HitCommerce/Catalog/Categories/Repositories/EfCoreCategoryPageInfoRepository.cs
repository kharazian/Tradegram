using System;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Categories.Repositories
{
    public class EfCoreCategoryPageInfoRepository : EfCoreRepository<ICatalogDbContext, CategoryPageInfo, Guid>,
        ICategoryPageInfoRepository
    {
        public EfCoreCategoryPageInfoRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
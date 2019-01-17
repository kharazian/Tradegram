using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommon.Contents;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class EfCoreCategoryRepository : EfCoreContentBaseRepository<Category, ICatalogDbContext>,
        ICategoryRepository
    {
        public EfCoreCategoryRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Category>> GetListByParentIdAsync(Guid parentId)
        {
            return await DbSet.Where(x => x.ParentCategoryId == parentId).OrderByDescending(x => x.Name)
                .ToListAsync();
        }
    }
}
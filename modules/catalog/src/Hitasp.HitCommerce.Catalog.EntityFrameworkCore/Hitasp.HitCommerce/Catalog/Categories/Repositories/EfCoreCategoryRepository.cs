using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Categories.Repositories
{
    public class EfCoreCategoryRepository : EfCoreRepository<ICatalogDbContext, Category, Guid>,
        ICategoryRepository
    {
        public EfCoreCategoryRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Category>> GetListRootCategory(bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            return includeDetails
                ? await WithDetails().Where(x => x.ParentCategoryId == null)
                    .ToListAsync(GetCancellationToken(cancellationToken))
                : await DbSet.Where(x => x.ParentCategoryId == null)
                    .ToListAsync(GetCancellationToken(cancellationToken));
        }
        
        public async Task<List<Category>> GetListByParentIdAsync(Guid parentId,
            bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return includeDetails
                ? await WithDetails().Where(x => x.ParentCategoryId == parentId)
                    .ToListAsync(GetCancellationToken(cancellationToken))
                : await DbSet.Where(x => x.ParentCategoryId == parentId)
                    .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
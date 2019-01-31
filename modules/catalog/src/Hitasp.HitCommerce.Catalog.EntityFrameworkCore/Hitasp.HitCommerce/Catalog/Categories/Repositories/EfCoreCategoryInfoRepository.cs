using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Categories.Repositories
{
    public class EfCoreCategoryInfoRepository : EfCoreRepository<ICatalogDbContext, CategoryInfo, Guid>,
        ICategoryInfoRepository
    {
        public EfCoreCategoryInfoRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<CategoryInfo> FindByNameAsync(string name,
            CancellationToken cancellationToken = default)
        {
            return await WithDetails().FirstOrDefaultAsync(x => x.Name == name,
                GetCancellationToken(cancellationToken));
        }

        public async Task<CategoryInfo> FindByTitleAsync(string title,
            CancellationToken cancellationToken = default)
        {
            return await WithDetails().FirstOrDefaultAsync(x => x.Title == title,
                GetCancellationToken(cancellationToken));
        }
    }
}
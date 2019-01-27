using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Hitasp.HitCommerce.Catalog.Tagging.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Tagging.Repositories
{
    public class EfCoreProductTagRepository : EfCoreRepository<ICatalogDbContext, ProductTag, Guid>, IProductTagRepository
    {
        public EfCoreProductTagRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<ProductTag> GetByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstAsync(t => t.Name == name, GetCancellationToken(cancellationToken));
        }

        public async Task<ProductTag> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(t => t.Name == name, GetCancellationToken(cancellationToken));
        }

        public async Task<List<ProductTag>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(t => ids.Contains(t.Id)).ToListAsync(GetCancellationToken(cancellationToken));
        }

        public void DecreaseUsageCountOfTags(List<Guid> ids)
        {
            var tags = DbSet.Where(t => ids.Any(id => id == t.Id));

            foreach (var tag in tags)
            {
                tag.DecreaseUsageCount();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Catalog.Tagging.Repositories
{
    public class EfCoreTagRepository : EfCoreRepository<ICatalogDbContext, Tag, Guid>, ITagRepository
    {
        public EfCoreTagRepository(IDbContextProvider<ICatalogDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Tag>> GetListAsync(Guid spaceId, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(t=>t.SpaceId == spaceId).ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<Tag> GetByNameAsync(string name, Guid spaceId, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstAsync(t => t.SpaceId == spaceId && t.Name == name, GetCancellationToken(cancellationToken));
        }

        public async Task<Tag> FindByNameAsync(string name, Guid spaceId, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(t => t.SpaceId == spaceId && t.Name == name, GetCancellationToken(cancellationToken));
        }

        public async Task<List<Tag>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
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
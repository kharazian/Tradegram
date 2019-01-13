using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hitasp.HitCommon.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.Tagging
{
    public class EfCoreTagRepository : EfCoreRepository<IHitCommonDbContext, Tag, Guid>,
        ITagRepository
    {
        public EfCoreTagRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Tag>> GetListAsync(string entityTypeId)
        {
            return await DbSet.Where(t=>t.EntityTypeId == entityTypeId).ToListAsync();
        }

        public async Task<Tag> GetByNameAsync(string entityTypeId, string name)
        {
            return await DbSet.FirstAsync(t=> t.EntityTypeId == entityTypeId && t.Name == name);
        }

        public async Task<Tag> FindByNameAsync(string entityTypeId, string name)
        {
            return await DbSet.FirstOrDefaultAsync(t => t.EntityTypeId == entityTypeId && t.Name == name);
        }

        public async Task<List<Tag>> GetListAsync(IEnumerable<Guid> ids)
        {
            return await DbSet.Where(t => ids.Contains(t.Id)).ToListAsync();
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

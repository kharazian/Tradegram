using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.Entities
{
    public class EfCoreEntityTypeRepository : EfCoreRepository<IHitCommonDbContext, EntityType, string>,
        IEntityTypeRepository
    {
        public EfCoreEntityTypeRepository(IDbContextProvider<IHitCommonDbContext> dbContextProvider) : base(
            dbContextProvider)
        {
        }

        public async Task<List<EntityType>> GetListAsync(string areaName, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(x => x.AreaName == areaName)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public async Task<EntityType> FindByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Name == name,
                GetCancellationToken(cancellationToken));
        }
    }
}
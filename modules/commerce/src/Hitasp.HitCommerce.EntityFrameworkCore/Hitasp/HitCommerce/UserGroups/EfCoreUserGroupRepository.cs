using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hitasp.HitCommerce.EntityFrameworkCore;

namespace Hitasp.HitCommerce.UserGroups
{
    public class EfCoreUserGroupRepository : EfCoreRepository<HitCommerceDbContext, UserGroup, Guid>,
        IUserGroupRepository
    {
        public EfCoreUserGroupRepository(IDbContextProvider<HitCommerceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<UserGroup>> GetAllActiveGroupsAsync()
        {
            return await DbSet.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<List<UserGroup>> GetListAsync(IEnumerable<Guid> ids)
        {
            return await DbSet.Where(t => ids.Contains(t.Id)).ToListAsync();
        }

        public async Task<UserGroup> FindByNameAsync(string name)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
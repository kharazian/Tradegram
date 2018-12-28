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

        public async Task<List<UserGroup>> GetAllActiveGroups()
        {
            return await DbSet.Where(x => x.IsActive).ToListAsync();
        }

        public async Task<UserGroup> GetByName(string name)
        {
            return await DbSet.WhereIf(!string.IsNullOrWhiteSpace(name), x => x.Name == name)
                .FirstOrDefaultAsync();
        }
    }
}
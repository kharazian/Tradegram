using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using Hitasp.HitCommerce.MongoDB;

namespace Hitasp.HitCommerce.UserGroups
{
    public class MongoUserGroupRepository : MongoDbRepository<IHitCommerceMongoDbContext, UserGroup, Guid>,
        IUserGroupRepository
    {
        public MongoUserGroupRepository(IMongoDbContextProvider<IHitCommerceMongoDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<List<UserGroup>> GetAllActiveGroups()
        {
            return await GetMongoQueryable().Where(x => x.IsActive).ToListAsync();
        }

        public async Task<UserGroup> GetByName(string name)
        {
            return await GetMongoQueryable().FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
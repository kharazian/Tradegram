using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.UserGroups
{
    public interface IUserGroupRepository : IBasicRepository<UserGroup, Guid>
    {
        Task<List<UserGroup>> GetAllActiveGroupsAsync();
        
        Task<List<UserGroup>> GetListAsync(IEnumerable<Guid> ids);
        
        Task<UserGroup> FindByNameAsync(string name);

        Task<UserGroup> GetByNameAsync(string name);
    }
}
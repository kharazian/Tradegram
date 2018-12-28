using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.UserGroups
{
    public interface IUserGroupRepository : IBasicRepository<UserGroup, Guid>
    {
        Task<List<UserGroup>> GetAllActiveGroups();

        Task<UserGroup> GetByName(string name);
    }
}
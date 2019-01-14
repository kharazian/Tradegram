using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.UserGroups.Dtos;

namespace Hitasp.HitCommerce.UserGroups
{
    public interface IUserGroupAppService : IAsyncCrudAppService<UserGroupDto, Guid,
        UserGroupGetListInput, UserGroupCreateDto, UserGroupUpdateDto>
    {
        Task<UserGroupDto> GetByNameAsync(UserGroupGetByNameInput input);
    }
}
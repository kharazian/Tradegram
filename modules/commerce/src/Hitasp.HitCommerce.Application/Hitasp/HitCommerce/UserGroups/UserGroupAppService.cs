using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.UserGroups.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.UserGroups
{
    public class UserGroupAppService : AsyncCrudAppService<UserGroup, UserGroupDto, Guid,
            UserGroupGetListInput, UserGroupCreateDto, UserGroupUpdateDto>
        , IUserGroupAppService
    {
        private readonly IUserGroupRepository _userGroupRepository;

        public UserGroupAppService(IUserGroupRepository userGroupRepository) : base(userGroupRepository)
        {
            _userGroupRepository = userGroupRepository;
        }

        public async Task<UserGroupDto> GetByNameAsync(UserGroupGetByNameInput input)
        {
            var userGroup = await _userGroupRepository.FindByNameAsync(input.UserGroupName);

            return input.StatusFilter && !userGroup.IsActive
                ? null
                : MapToEntityDto(userGroup);
        }
    }
}
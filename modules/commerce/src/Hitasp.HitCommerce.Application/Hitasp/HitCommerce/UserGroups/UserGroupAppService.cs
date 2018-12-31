using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hitasp.HitCommerce.UserGroups.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;


namespace Hitasp.HitCommerce.UserGroups
{
    public class UserGroupAppService : ApplicationService, IUserGroupAppService
    {
        private readonly IUserGroupRepository _userGroupRepository;

        public UserGroupAppService(IUserGroupRepository userGroupRepository)
        {
            _userGroupRepository = userGroupRepository;
        }

        public async Task<PagedResultDto<UserGroupWithDetailDto>> GetListAsync(UserGroupGetListInput input)
        {
            var userGroups = await _userGroupRepository.GetListAsync(true);

            var query = userGroups.Select(userGroup => new UserGroupWithDetailDto
                {
                    UserGroup = ObjectMapper.Map<UserGroup, UserGroupDto>(userGroup),
                    IsActive = userGroup.IsActive,
                    MembersCount = userGroup.Members.LongCount()
                })
                .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), x =>
                    x.UserGroup.Name.Contains(input.NameFilter) ||
                    x.UserGroup.Description.Contains(input.NameFilter))
                .WhereIf(input.StatusFilter, x => x.IsActive);

            var output = query.ToList();

            var totalCount = output.LongCount();

            return new PagedResultDto<UserGroupWithDetailDto>(totalCount, output);
        }

        public async Task<UserGroupForEditOutput> GetForEditAsync(Guid userGroupId)
        {
            var userGroup = await _userGroupRepository.FindAsync(userGroupId);

            if (userGroup == null)
            {
                return null;
            }

            var output = new UserGroupForEditOutput
            {
                UserGroup = ObjectMapper.Map<UserGroup, UserGroupCreateOrEditDto>(userGroup)
            };

            return output;
        }

        public async Task<UserGroupWithDetailDto> CreateOrEditAsync(UserGroupCreateOrEditDto input)
        {
            UserGroup userGroup;

            if (input.Id == null)
            {
                userGroup = await Create(input);
            }
            else
            {
                userGroup = await Update(input);
            }

            return new UserGroupWithDetailDto
            {
                UserGroup = ObjectMapper.Map<UserGroup, UserGroupDto>(userGroup),
                IsActive = userGroup.IsActive,
                MembersCount = userGroup.Members.LongCount()
            };
        }

        public async Task DeleteAsync(Guid userGroupId)
        {
            await _userGroupRepository.DeleteAsync(userGroupId);
        }
        
        private async Task<UserGroup> Create(UserGroupCreateOrEditDto input)
        {
            var userGroup = new UserGroup(
                GuidGenerator.Create(),
                input.Name
            );

            userGroup.SetDescription(input.Description);
            userGroup.UpdateStatus(input.IsActive);

            return await _userGroupRepository.InsertAsync(userGroup);
        }

        private async Task<UserGroup> Update(UserGroupCreateOrEditDto input)
        {
            var userGroup = await _userGroupRepository.GetAsync((Guid) input.Id);

            userGroup.SetName(input.Name);
            userGroup.SetDescription(input.Description);
            userGroup.UpdateStatus(input.IsActive);

            return await _userGroupRepository.UpdateAsync(userGroup);
        }
    }
}
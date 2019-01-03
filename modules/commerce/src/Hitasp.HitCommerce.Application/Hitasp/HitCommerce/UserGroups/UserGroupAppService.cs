using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Customers;
using Hitasp.HitCommerce.Customers.Dtos;
using Hitasp.HitCommerce.UserGroups.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitCommerce.UserGroups
{
    public class UserGroupAppService : ApplicationService, IUserGroupAppService
    {
        private readonly IUserGroupRepository _userGroupRepository;

        public UserGroupAppService(
            IUserGroupRepository userGroupRepository
            )
        {
            _userGroupRepository = userGroupRepository;
        }

        public async Task<PagedResultDto<UserGroupWithDetailDto>> GetListAsync(UserGroupGetListInput input)
        {
            var userGroups = await _userGroupRepository.GetListAsync(true);

            var query = userGroups.Select(userGroup => new UserGroupWithDetailDto
                {
                    UserGroup = ObjectMapper.Map<UserGroup, UserGroupDto>(userGroup)
                })
                .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), x =>
                    x.UserGroup.Name.Contains(input.NameFilter) ||
                    x.UserGroup.Description.Contains(input.NameFilter))
                .WhereIf(input.StatusFilter, x => x.UserGroup.IsActive);

            var output = query.ToList();

            var totalCount = output.LongCount();

            return new PagedResultDto<UserGroupWithDetailDto>(totalCount, output);
        }

        public async Task<UserGroupWithDetailDto> GetByNameAsync(UserGroupGetByNameInput input)
        {
            var userGroup = await _userGroupRepository.FindByNameAsync(input.UserGroupName);

            if (input.StatusFilter)
            {
                return userGroup.IsActive == input.StatusFilter
                    ? new UserGroupWithDetailDto
                    {
                        UserGroup = ObjectMapper.Map<UserGroup, UserGroupDto>(userGroup)
                    }
                    : null;
            }

            return new UserGroupWithDetailDto
            {
                UserGroup = ObjectMapper.Map<UserGroup, UserGroupDto>(userGroup)
            };
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
            if (input.Id == null)
            {
                return await Create(input);
            }

            return await Update(input);
        }

        public async Task DeleteAsync(Guid userGroupId)
        {
            await _userGroupRepository.DeleteAsync(userGroupId);
        }
        
        private async Task<UserGroupWithDetailDto> Create(UserGroupCreateOrEditDto input)
        {
            var userGroup = new UserGroup(
                GuidGenerator.Create(),
                input.Name
            );

            userGroup.SetDescription(input.Description);
            userGroup.UpdateStatus(input.IsActive);

            await _userGroupRepository.InsertAsync(userGroup);
            
            return new UserGroupWithDetailDto
            {
                UserGroup = ObjectMapper.Map<UserGroup, UserGroupDto>(userGroup)
            };
        }

        private async Task<UserGroupWithDetailDto> Update(UserGroupCreateOrEditDto input)
        {
            var userGroup = await _userGroupRepository.GetAsync((Guid) input.Id);

            userGroup.SetName(input.Name);
            userGroup.SetDescription(input.Description);
            userGroup.UpdateStatus(input.IsActive);

            await _userGroupRepository.UpdateAsync(userGroup);

            return new UserGroupWithDetailDto
            {
                UserGroup = ObjectMapper.Map<UserGroup, UserGroupDto>(userGroup)
            };
        }
    }
}
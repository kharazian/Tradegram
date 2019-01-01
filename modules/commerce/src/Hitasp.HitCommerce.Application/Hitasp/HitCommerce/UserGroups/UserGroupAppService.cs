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
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerUserGroupRepository _customerUserGroupRepository;

        public UserGroupAppService(
            IUserGroupRepository userGroupRepository,
            ICustomerUserGroupRepository customerUserGroupRepository,
            ICustomerRepository customerRepository
            )
        {
            _userGroupRepository = userGroupRepository;
            _customerUserGroupRepository = customerUserGroupRepository;
            _customerRepository = customerRepository;
        }

        public async Task<PagedResultDto<UserGroupWithDetailDto>> GetListAsync(UserGroupGetListInput input)
        {
            var userGroups = await _userGroupRepository.GetListAsync(true);

            var query = userGroups.Select(userGroup => new UserGroupWithDetailDto
                {
                    UserGroup = ObjectMapper.Map<UserGroup, UserGroupDto>(userGroup),
                    IsActive = userGroup.IsActive,
                    MembersCount = userGroup.Members.LongCount(),
                    Members = new List<CustomerInListDto>() //ignore fetching member list for GetList request
                })
                .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), x =>
                    x.UserGroup.Name.Contains(input.NameFilter) ||
                    x.UserGroup.Description.Contains(input.NameFilter))
                .WhereIf(input.StatusFilter, x => x.IsActive);

            var output = query.ToList();

            var totalCount = output.LongCount();

            return new PagedResultDto<UserGroupWithDetailDto>(totalCount, output);
        }

        public async Task<UserGroupWithDetailDto> GetByNameAsync(UserGroupGetByNameInput input)
        {
            var userGroup = await _userGroupRepository.FindByNameAsync(input.UserGroupName);

            var groupMemberIds =
                (await _customerUserGroupRepository.GetListAsync())
                .Where(x => x.UserGroupId == userGroup.Id).Select(x => x.CustomerId).ToList();

            var groupMembers = await _customerRepository.GetListAsync(groupMemberIds);
            
            return new UserGroupWithDetailDto
            {
                UserGroup = ObjectMapper.Map<UserGroup, UserGroupDto>(userGroup),
                IsActive = userGroup.IsActive,
                Members = ObjectMapper.Map<List<Customer>, List<CustomerInListDto>>(groupMembers),
                MembersCount = groupMembers.LongCount()
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
            await _customerUserGroupRepository.InsertAsync(new CustomerUserGroup(
                input.CustomerId,
                userGroup.Id)
            );
            
            var groupMemberIds =
                (await _customerUserGroupRepository.GetListAsync())
                .Where(x => x.UserGroupId == userGroup.Id).Select(x => x.CustomerId).ToList();

            var groupMembers = await _customerRepository.GetListAsync(groupMemberIds);
            
            return new UserGroupWithDetailDto
            {
                UserGroup = ObjectMapper.Map<UserGroup, UserGroupDto>(userGroup),
                IsActive = userGroup.IsActive,
                Members = ObjectMapper.Map<List<Customer>, List<CustomerInListDto>>(groupMembers),
                MembersCount = groupMembers.LongCount()
            };
        }

        private async Task<UserGroupWithDetailDto> Update(UserGroupCreateOrEditDto input)
        {
            var userGroup = await _userGroupRepository.GetAsync((Guid) input.Id);

            userGroup.SetName(input.Name);
            userGroup.SetDescription(input.Description);
            userGroup.UpdateStatus(input.IsActive);

            await _userGroupRepository.UpdateAsync(userGroup);
            
            var groupMemberIds =
                (await _customerUserGroupRepository.GetListAsync())
                .Where(x => x.UserGroupId == userGroup.Id).Select(x => x.CustomerId).ToList();

            var groupMembers = await _customerRepository.GetListAsync(groupMemberIds);
            
            return new UserGroupWithDetailDto
            {
                UserGroup = ObjectMapper.Map<UserGroup, UserGroupDto>(userGroup),
                IsActive = userGroup.IsActive,
                Members = ObjectMapper.Map<List<Customer>, List<CustomerInListDto>>(groupMembers),
                MembersCount = groupMembers.LongCount()
            };
        }
    }
}
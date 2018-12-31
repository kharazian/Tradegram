using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hitasp.HitCommerce.Customers.Dtos;
using Hitasp.HitCommerce.UserGroups;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;

namespace Hitasp.HitCommerce.Customers
{
    public class CustomerGroupAppService : ApplicationService, ICustomerGroupAppService
    {
        private readonly ICustomerLookupService _customerLookupService;
        private readonly ICustomerUserGroupRepository _customerUserGroupRepository;
        private readonly IUserGroupRepository _userGroupRepository;

        public CustomerGroupAppService(
            ICustomerUserGroupRepository customerUserGroupRepository,
            ICustomerLookupService customerLookupService, IUserGroupRepository userGroupRepository)
        {
            _customerUserGroupRepository = customerUserGroupRepository;
            _customerLookupService = customerLookupService;
            _userGroupRepository = userGroupRepository;
        }

        public async Task<PagedResultDto<CustomerGroupForViewDto>> GetListByCustomerIdAsync(CustomerGroupGetAllDto input)
        {
            var customer = await _customerLookupService.FindByIdAsync(input.CustomerId);

            if (customer == null)
            {
                return null;
            }

            var customerUserGroups = await _customerUserGroupRepository.ListByCustomerId(customer.Id);

            var query = (from customerUserGroup in customerUserGroups

                    join userGroup in _userGroupRepository.GetList() on customerUserGroup.UserGroupId
                    equals userGroup.Id into joinedUserGroup
                    from customerGroup in joinedUserGroup.DefaultIfEmpty()
                    where customerGroup.IsActive
                    
                    select new CustomerGroupForViewDto
                    {
                        CustomerGroup = ObjectMapper.Map<UserGroup, CustomerGroupDto>(customerGroup)
                    })
                
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), x =>
                    x.CustomerGroup.Name.Contains(input.Filter) ||
                    x.CustomerGroup.Description.Contains(input.Filter));

            var output = query.ToList();

            var totalCount = output.LongCount();
            
            return new PagedResultDto<CustomerGroupForViewDto>(totalCount, output);
        }

        public async Task<PagedResultDto<CustomerGroupForViewDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var userGroups = await _userGroupRepository.GetAllActiveGroupsAsync();

            var query = userGroups.Select(userGroup => new CustomerGroupForViewDto
            {
                CustomerGroup = ObjectMapper.Map<UserGroup, CustomerGroupDto>(userGroup)
            });
            
            var output = query.ToList();

            var totalCount = output.LongCount();
            
            return new PagedResultDto<CustomerGroupForViewDto>(totalCount, output);
        }

        public async Task<CustomerGroupForEditDto> GetForEditAsync(Guid id)
        {
            if (CurrentUser == null)
            {
                return null;
            }
            
            var customerUserGroup = (await _customerUserGroupRepository.ListByCustomerId((Guid) CurrentUser.Id))
                .FirstOrDefault(x => x.UserGroupId == id);
            
            if (customerUserGroup == null)
            {
                return null;
            }
            
            var userGroup = await _userGroupRepository.GetAsync(customerUserGroup.UserGroupId);

            
            var output = new CustomerGroupForEditDto
            {
                CustomerGroup = ObjectMapper.Map<UserGroup, CustomerGroupCreateOrEditDto>(userGroup)
            };

            return output;
        }

        public async Task<CustomerGroupForViewDto> CreateOrEditAsync(CustomerGroupCreateOrEditDto input)
        {
            var customer = await _customerLookupService.GetByIdAsync((Guid) CurrentUser.Id);

            if (customer == null)
            {
                return null;
            }

            UserGroup userGroup;

            if (!input.Id.HasValue)
            {
                userGroup = await _userGroupRepository.InsertAsync(new UserGroup(
                    GuidGenerator.Create(),
                    input.Name
                ));

                userGroup.SetName(input.Name);
                userGroup.SetDescription(input.Description);

                await _userGroupRepository.InsertAsync(userGroup);
                
                customer.JoinGroup(userGroup.Id);
                
                await CurrentUnitOfWork.SaveChangesAsync();
            }
            else
            {
                userGroup = await _userGroupRepository.GetAsync(input.Id.Value);

                if (userGroup.CreatorId != CurrentUser.Id)
                {
                    throw new UserFriendlyException("AccessDenied");
                }

                userGroup.SetName(input.Name);

                if (!string.IsNullOrWhiteSpace(input.Description))
                {
                    userGroup.SetDescription(input.Description);
                }

                if (userGroup.IsActive)
                {
                    userGroup.UpdateStatus();
                }
                
                customer.JoinGroup(userGroup.Id);

                await CurrentUnitOfWork.SaveChangesAsync();
            }
            
            return new CustomerGroupForViewDto
            {
                CustomerGroup = ObjectMapper.Map<UserGroup, CustomerGroupDto>(userGroup)
            };
        }

        public async Task DeleteAsync(Guid id)
        {
            var userGroup = await _userGroupRepository.GetAsync(id);
            
            
        }
    }
}
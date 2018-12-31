using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.UserGroups.Dtos;

namespace Hitasp.HitCommerce.UserGroups
{
    public interface IUserGroupAppService : IApplicationService
    {
        Task<PagedResultDto<UserGroupWithDetailDto>> GetListAsync(UserGroupGetListInput input);

        Task<UserGroupForEditOutput> GetForEditAsync(Guid userGroupId);

        Task<UserGroupWithDetailDto> CreateOrEditAsync(UserGroupCreateOrEditDto input);

        Task DeleteAsync(Guid userGroupId);
    }
}
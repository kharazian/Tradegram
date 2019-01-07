using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hitasp.HitLocation.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitLocation
{
    public interface ILocationsAppService : IApplicationService
    {
        Task<UserLocationDto> GetUserLocationAsync(Guid userId);

        Task<ListResultDto<LocationsDto>> GetAllLocationsAsync();

        Task<LocationsDto> GetLocationAsync(int locationId);

        Task CreateOrUpdateUserLocationAsync(LocationRequestInput input);
    }
}
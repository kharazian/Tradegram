using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hitasp.HitLocation.Dtos;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hitasp.HitLocation
{
    public class LocationsAppService : ApplicationService, ILocationsAppService
    {
        private readonly ILocationsService _locationsService;

        public LocationsAppService(ILocationsService locationsService)
        {
            Check.NotNull(locationsService, nameof(locationsService));
            
            _locationsService = locationsService;
        }

        public async Task<UserLocationDto> GetUserLocationAsync(Guid userId)
        {
            var userLocation = await _locationsService.GetUserLocationAsync(userId);

            return ObjectMapper.Map<UserLocation, UserLocationDto>(userLocation);
        }

        public async Task<ListResultDto<LocationsDto>> GetAllLocationsAsync()
        {
            var locationsList = await _locationsService.GetAllLocationAsync();

            return new ListResultDto<LocationsDto>(
                ObjectMapper.Map<List<Locations>, List<LocationsDto>>(locationsList)
            );
        }

        public async Task<LocationsDto> GetLocationAsync(int locationId)
        {
            var location = await _locationsService.GetLocationAsync(locationId);

            return ObjectMapper.Map<Locations, LocationsDto>(location);
        }

        public async Task CreateOrUpdateUserLocationAsync(LocationRequestInput input)
        {
            if (CurrentUser.Id.HasValue)
            {
                await _locationsService.AddOrUpdateUserLocationAsync(CurrentUser.Id.Value, input.Longitude, input.Latitude);
            }
        }
    }
}
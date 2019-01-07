using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitLocation
{
    public class LocationsService : DomainService, ILocationsService
    {
        private readonly ILocationsRepository _locationsRepository;
        private readonly IUserLocationRepository _userLocationRepository;

        public LocationsService(
            ILocationsRepository locationsRepository,
            IUserLocationRepository userLocationRepository)
        {
            Check.NotNull(locationsRepository, nameof(locationsRepository));
            Check.NotNull(userLocationRepository, nameof(userLocationRepository));

            _locationsRepository = locationsRepository;
            _userLocationRepository = userLocationRepository;
        }

        public async Task<Locations> GetLocationAsync(int locationId)
        {
            return await _locationsRepository.GetAsync(locationId);
        }

        public async Task<UserLocation> GetUserLocationAsync(Guid userId)
        {
            return await _userLocationRepository.GetUserLocationAsync(userId);
        }

        public async Task<List<Locations>> GetAllLocationAsync()
        {
            return await _locationsRepository.GetListAsync();
        }

        public async Task AddOrUpdateUserLocationAsync(Guid userId, double longitude, double latitude)
        {
            var currentUserAreaLocationList =
                await _locationsRepository.GetCurrentUserRegionsListAsync(longitude, latitude);

            if (currentUserAreaLocationList is null)
            {
                throw new AbpException("User current area not found");
            }

            var userLocation = await _userLocationRepository.GetUserLocationAsync(userId);

            if (userLocation is null)
            {
                await _userLocationRepository.InsertAsync(new UserLocation(
                    userId,
                    currentUserAreaLocationList[0].LocationId));
                
                return;
            }

            userLocation.LocationId = currentUserAreaLocationList[0].LocationId;
            userLocation.UpdateDate = DateTime.UtcNow;

            await _userLocationRepository.UpdateAsync(userLocation, true);
        }
    }
}
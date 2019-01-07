using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitLocation
{
    public interface ILocationsService : IDomainService
    {
        Task<Locations> GetLocationAsync(int locationId);

        Task<UserLocation> GetUserLocationAsync(Guid userId);

        Task<List<Locations>> GetAllLocationAsync();

        Task AddOrUpdateUserLocationAsync(Guid userId, double longitude, double latitude);
    }
}

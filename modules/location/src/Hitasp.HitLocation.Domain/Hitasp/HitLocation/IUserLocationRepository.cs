using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitLocation
{
    public interface IUserLocationRepository : IBasicRepository<UserLocation>
    {
        Task<UserLocation> GetUserLocationAsync(Guid userId);
    }
}
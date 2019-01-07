using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitLocation
{
    public interface ILocationsRepository : IBasicRepository<Locations, string>
    {        
        Task<Locations> GetAsync(int locationId);

        Task<List<Locations>> GetCurrentUserRegionsListAsync(double longitude, double latitude);
    }
}
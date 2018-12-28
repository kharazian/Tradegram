using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Directions
{
    public interface IDistrictRepository : IBasicRepository<District, Guid>
    {
        Task<List<District>> GetAllByStateOrProvinceId(Guid stateOrProvinceId);

        Task<District> GetByName(string name);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Directions
{
    public interface IDistrictRepository : IRepository<District, Guid>
    {
        Task<List<District>> ListByStateOrProvinceId(Guid stateOrProvinceId);

        Task<District> FindByName(string name);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Directions
{
    public interface IStateOrProvinceRepository : IRepository<StateOrProvince, Guid>
    {
        Task<List<StateOrProvince>> ListByCountryId(Guid countryId);

        Task<StateOrProvince> FindByName(string name);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Directions
{
    public interface ICountryRepository : IRepository<Country, Guid>
    {
        Task<List<Country>> FindAllCountriesForBilling();

        Task<List<Country>> FindAllCountriesForShipping();
    }
}
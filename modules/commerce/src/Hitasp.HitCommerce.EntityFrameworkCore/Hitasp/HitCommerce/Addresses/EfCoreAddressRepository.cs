using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hitasp.HitCommerce.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Addresses
{
    public class EfCoreAddressRepository: EfCoreRepository<IHitCommerceDbContext, Address, Guid>, IAddressRepository
    {
        public EfCoreAddressRepository(IDbContextProvider<IHitCommerceDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public async Task<int> GetAddressTotalByCountryId(Guid countryId)
        {
            return await DbSet.Where(x => x.CountryId == countryId).CountAsync();
        }

        public async Task<int> GetAddressTotalByStateOrProvinceId(Guid stateOrProvinceId)
        {
            return await DbSet.Where(x => x.StateOrProvinceId == stateOrProvinceId).CountAsync();
        }

        public async Task<int> GetAddressTotalByDistrictId(Guid districtId)
        {
            return await DbSet.Where(x => x.DistrictId.HasValue && x.DistrictId == districtId).CountAsync();
        }
    }
}
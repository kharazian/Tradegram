using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hitasp.HitCommerce.EntityFrameworkCore;

namespace Hitasp.HitCommerce.Directions
{
    public class EfCoreDistrictRepository : EfCoreRepository<HitCommerceDbContext, District, Guid>,
        IDistrictRepository
    {
        public EfCoreDistrictRepository(IDbContextProvider<HitCommerceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<District>> GetAllByStateOrProvinceId(Guid stateOrProvinceId)
        {
            return await DbSet.Where(x => x.StateOrProvinceId == stateOrProvinceId).ToListAsync();
        }

        public async Task<District> GetByName(string name)
        {
            return await DbSet.WhereIf(!string.IsNullOrWhiteSpace(name), x => x.Name == name)
                .FirstOrDefaultAsync();
        }
    }
}
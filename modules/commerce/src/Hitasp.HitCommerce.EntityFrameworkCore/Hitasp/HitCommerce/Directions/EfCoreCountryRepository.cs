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
    public class EfCoreCountryRepository : EfCoreRepository<HitCommerceDbContext, Country, Guid>, ICountryRepository
    {
        public EfCoreCountryRepository(IDbContextProvider<HitCommerceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Country>> FindAllCountriesForBilling()
        {
            return await DbSet.Where(x => x.IsBillingEnabled).ToListAsync();
        }

        public async Task<List<Country>> FindAllCountriesForShipping()
        {
            return await DbSet.Where(x => x.IsShippingEnabled).ToListAsync();
        }
    }
}
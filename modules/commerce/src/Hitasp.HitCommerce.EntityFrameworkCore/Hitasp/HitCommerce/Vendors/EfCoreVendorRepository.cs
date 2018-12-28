using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hitasp.HitCommerce.EntityFrameworkCore;


namespace Hitasp.HitCommerce.Vendors
{
    public class EfCoreVendorRepository: EfCoreRepository<HitCommerceDbContext, Vendor, Guid>,
        IVendorRepository

    {
        public EfCoreVendorRepository(IDbContextProvider<HitCommerceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Vendor> GetByName(string name)
        {
            return await DbSet.WhereIf(!string.IsNullOrWhiteSpace(name), x => x.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task<Vendor> GetBySlug(string slug)
        {
            return await DbSet.WhereIf(!string.IsNullOrWhiteSpace(slug), x => x.Slug == slug)
                .FirstOrDefaultAsync();
        }

        public async Task<Vendor> GetByEmailAddress(string emailAddress)
        {
            return await DbSet.WhereIf(!string.IsNullOrWhiteSpace(emailAddress), x => x.Email == emailAddress)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Vendor>> GetActives()
        {
            return await DbSet.Where(x => x.IsActive).ToListAsync();
        }
    }
}
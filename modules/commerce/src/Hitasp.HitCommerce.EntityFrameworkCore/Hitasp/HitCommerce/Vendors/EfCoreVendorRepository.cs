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

        public async Task<Vendor> FindByName(string name)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Vendor> FindBySlug(string slug)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Slug == slug);
        }

        public async Task<Vendor> FindByEmailAddress(string emailAddress)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Email == emailAddress);
        }

        public async Task<List<Vendor>> GetActives()
        {
            return await DbSet.Where(x => x.IsActive).ToListAsync();
        }
    }
}
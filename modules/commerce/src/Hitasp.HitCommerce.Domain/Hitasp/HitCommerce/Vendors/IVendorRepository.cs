using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Vendors
{
    public interface IVendorRepository : IRepository<Vendor, Guid>
    {
        Task<Vendor> FindByName(string name);

        Task<Vendor> FindBySlug(string slug);

        Task<Vendor> FindByEmailAddress(string emailAddress);

        Task<List<Vendor>> GetActives();
    }
}
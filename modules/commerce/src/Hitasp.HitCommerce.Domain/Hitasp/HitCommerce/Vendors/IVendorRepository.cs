using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Vendors
{
    public interface IVendorRepository : IBasicRepository<Vendor, Guid>
    {
        Task<Vendor> GetByName(string name);

        Task<Vendor> GetBySlug(string slug);

        Task<Vendor> GetByEmailAddress(string emailAddress);

        Task<List<Vendor>> GetActives();
    }
}
using System;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public interface IBrandRepository : IBasicRepository<Brand, Guid>
    {
        
    }
}
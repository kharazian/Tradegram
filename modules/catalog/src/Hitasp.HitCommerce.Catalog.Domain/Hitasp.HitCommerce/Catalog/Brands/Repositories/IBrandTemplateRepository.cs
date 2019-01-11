using System;
using Hitasp.HitCommerce.Catalog.Brands.Aggregates;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Brands.Repositories
{
    public interface IBrandTemplateRepository : IBasicRepository<BrandTemplate, Guid>
    {
        
    }
}
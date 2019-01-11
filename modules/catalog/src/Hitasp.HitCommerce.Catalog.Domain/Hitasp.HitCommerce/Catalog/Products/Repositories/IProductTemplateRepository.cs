using System;
using Hitasp.HitCommerce.Catalog.Products.Aggregates;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public interface IProductTemplateRepository : IBasicRepository<ProductTemplate, Guid>
    {
        
    }
}
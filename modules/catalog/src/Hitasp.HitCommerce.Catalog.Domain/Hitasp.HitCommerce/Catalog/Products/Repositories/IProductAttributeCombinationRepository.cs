using System;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public interface IProductAttributeCombinationRepository : IRepository<ProductAttributeCombination, Guid>
    {
        
    }
}
using System;
using Hitasp.HitCommerce.Catalog.Attributes.Entities;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Attributes.Repositories
{
    public interface IProductAttributeRepository : IRepository<ProductAttribute, Guid>
    {
        
    }
}
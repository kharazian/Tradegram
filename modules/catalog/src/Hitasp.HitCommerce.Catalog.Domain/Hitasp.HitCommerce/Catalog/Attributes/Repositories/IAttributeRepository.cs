using System;
using Volo.Abp.Domain.Repositories;
using Attribute = Hitasp.HitCommerce.Catalog.Attributes.Aggregates.Attribute;

namespace Hitasp.HitCommerce.Catalog.Attributes.Repositories
{
    public interface IAttributeRepository : IBasicRepository<Attribute, Guid>
    {
        
    }
}
using System;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Attributes
{
    public interface IAttributeGroupRepository : IBasicRepository<AttributeGroup, Guid>
    {
        
    }
}
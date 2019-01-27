using System;
using Hitasp.HitCommerce.Catalog.Attributes.Entities;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Attributes.Repositories
{
    public interface IPredefinedAttributeValueRepository : IRepository<PredefinedAttributeValue, Guid>
    {
        
    }
}
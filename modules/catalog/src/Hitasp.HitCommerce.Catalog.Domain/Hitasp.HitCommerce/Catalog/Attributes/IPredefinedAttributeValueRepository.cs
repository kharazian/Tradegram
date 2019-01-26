using System;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Attributes
{
    public interface IPredefinedAttributeValueRepository : IRepository<PredefinedAttributeValue, Guid>
    {
        
    }
}
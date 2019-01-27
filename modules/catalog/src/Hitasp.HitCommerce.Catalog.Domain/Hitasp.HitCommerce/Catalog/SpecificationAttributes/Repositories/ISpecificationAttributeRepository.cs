using System;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Aggregates;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.SpecificationAttributes.Repositories
{
    public interface ISpecificationAttributeRepository : IRepository<SpecificationAttribute, Guid>
    {
        
    }
}
using System;
using Hitasp.HitCommerce.Catalog.SpecificationAttributes.Entities;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.SpecificationAttributes.Repositories
{
    public interface ISpecificationAttributeOptionRepository : IRepository<SpecificationAttributeOption, Guid>
    {
    }
}
using System;
using Hitasp.HitCommerce.Catalog.Categories.Aggregates;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Categories.Repositories
{
    public interface ICategoryRepository : IBasicRepository<Category, Guid>
    {
        
    }
}
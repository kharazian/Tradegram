using System;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public interface ICategoryRepository : IBasicRepository<Category, Guid>
    {
        
    }
}
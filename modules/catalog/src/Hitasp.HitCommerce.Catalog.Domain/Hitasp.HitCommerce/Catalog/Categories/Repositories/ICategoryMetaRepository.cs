using System;
using Hitasp.HitCommerce.Catalog.Categories.Entities;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Categories.Repositories
{
    public interface ICategoryMetaRepository : IRepository<CategoryMeta, Guid>
    {
    }
}
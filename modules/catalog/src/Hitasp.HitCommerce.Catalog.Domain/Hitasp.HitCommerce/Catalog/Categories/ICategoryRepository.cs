using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hitasp.HitCommon.Contents;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public interface ICategoryRepository : IContentBaseRepository<Category>
    {
        Task<List<Category>> GetListByParentIdAsync(Guid parentId);
    }
}
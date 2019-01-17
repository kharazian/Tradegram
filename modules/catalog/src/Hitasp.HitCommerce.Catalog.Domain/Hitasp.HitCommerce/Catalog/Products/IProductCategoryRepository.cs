using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public interface IProductCategoryRepository : IBasicRepository<ProductCategory>
    {
        Task<List<ProductCategory>> GetListByCategoryId(Guid categoryId);
    }
}
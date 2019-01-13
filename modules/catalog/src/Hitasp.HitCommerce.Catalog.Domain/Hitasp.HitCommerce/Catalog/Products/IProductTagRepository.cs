using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public interface IProductTagRepository : IBasicRepository<ProductTag>
    {
        void DeleteOfProduct(Guid productId);
        
        Task<ProductTag> FindByTagIdAndProductIdAsync(Guid productId, Guid tagId);
    }
}
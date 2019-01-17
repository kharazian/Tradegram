using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hitasp.HitCommon.Contents;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public interface IProductRepository : IContentBaseRepository<Product>
    {
        Task<List<Product>> GetListAsync(IEnumerable<Guid> ids);
    }
}
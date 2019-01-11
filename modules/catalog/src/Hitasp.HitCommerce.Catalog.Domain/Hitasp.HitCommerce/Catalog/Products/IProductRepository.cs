using System;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public interface IProductRepository : IBasicRepository<Product, Guid>
    {
        
    }
}
using System;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public interface IProductTemplateRepository : IRepository<ProductTemplate, Guid>
    {
        
    }
}
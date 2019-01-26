using System;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Products.Repositories
{
    public interface IProductShippingInfoRepository : IRepository<ProductShippingInfo, Guid>
    {
        
    }
}
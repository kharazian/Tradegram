using System;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Attributes
{
    public interface ICatalogAttributeRepository : IRepository<CatalogAttribute, Guid>
    {
        
    }
}
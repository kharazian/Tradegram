using System;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Repositories
{
    public interface IManufacturerRepository : IRepository<Manufacturer, Guid>
    {
    }
}
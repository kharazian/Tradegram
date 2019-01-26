using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Repositories
{
    public interface IManufacturerRepository : IRepository<Manufacturer, Guid>
    {
        Task<List<Manufacturer>> GetListAsync(Guid spaceId, bool includeDetails = false,
            CancellationToken cancellationToken = default);

        Task<Manufacturer> FindByNameAsync(string name,
            CancellationToken cancellationToken = default);

        Task<Manufacturer> FindByTitleAsync(string name,
            CancellationToken cancellationToken = default);
    }
}
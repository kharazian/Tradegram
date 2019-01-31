using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Repositories
{
    public interface IManufacturerInfoRepository : IRepository<ManufacturerInfo, Guid>
    {
        Task<ManufacturerInfo> FindByNameAsync(string name,
            CancellationToken cancellationToken = default);

        Task<ManufacturerInfo> FindByTitleAsync(string name,
            CancellationToken cancellationToken = default);
    }
}
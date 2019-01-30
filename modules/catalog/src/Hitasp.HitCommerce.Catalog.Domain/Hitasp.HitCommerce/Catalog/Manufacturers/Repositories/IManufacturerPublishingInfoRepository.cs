using System;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Repositories
{
    public interface IManufacturerPublishingInfoRepository : IRepository<ManufacturerPublishingInfo, Guid>
    {
    }
}
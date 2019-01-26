using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Catalog.Manufacturers
{
    public interface IManufacturerFactory : IDomainService
    {
        Task<Manufacturer> CreateManufacturerAsync(Guid manufacturerTemplateId,[NotNull] string name, [NotNull] string title, 
            bool isPublished);
    }
}
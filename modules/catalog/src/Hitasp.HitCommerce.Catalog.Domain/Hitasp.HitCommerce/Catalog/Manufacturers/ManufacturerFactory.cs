using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Hitasp.HitCommerce.Catalog.Manufacturers.Exceptions;
using Hitasp.HitCommerce.Catalog.Manufacturers.Repositories;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Catalog.Manufacturers
{
    public class ManufacturerFactory : DomainService, IManufacturerFactory
    {
        private readonly IManufacturerRepository _manufacturerRepository;

        public ManufacturerFactory(IManufacturerRepository manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        public async Task<Manufacturer> CreateManufacturerAsync(Guid manufacturerTemplateId, string name, string title)
        {
            if (await _manufacturerRepository.FindByNameAsync(name) != null)
            {
                throw new ManufacturerNameAlreadyExistsException(name);
            }
            
            var manufacturerId = GuidGenerator.Create();

            var manufacturer = new Manufacturer(
                manufacturerId,
                manufacturerTemplateId
            );

            var manufacturerInfo = new ManufacturerInfo(manufacturerId);
            var manufacturerMeta = new ManufacturerMetaInfo(manufacturerId);
            var manufacturerPageInfo = new ManufacturerPageInfo(manufacturerId);
            var publishingInfo = new ManufacturerPublishingInfo(manufacturerId);

            manufacturerInfo.SetName(name);
            manufacturerInfo.SetTitle(title);

            manufacturer.SetManufacturerInfo(manufacturerInfo);
            manufacturer.SetManufacturerMetaInfo(manufacturerMeta);
            manufacturer.SetManufacturerPageInfo(manufacturerPageInfo);
            manufacturer.SetManufacturerPublishingInfo(publishingInfo);

            return await _manufacturerRepository.InsertAsync(manufacturer);
        }
    }
}
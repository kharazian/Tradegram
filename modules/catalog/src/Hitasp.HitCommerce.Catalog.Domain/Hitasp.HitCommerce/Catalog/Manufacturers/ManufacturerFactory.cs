using System;
using System.Threading.Tasks;
using Hitasp.HitCommerce.Catalog.Manufacturers.Aggregates;
using Hitasp.HitCommerce.Catalog.Manufacturers.Entities;
using Hitasp.HitCommerce.Catalog.Manufacturers.Repositories;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Catalog.Manufacturers
{
    public class ManufacturerFactory : DomainService, IManufacturerFactory
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IManufacturerInfoRepository _infoRepository;
        private readonly IManufacturerMetaRepository _metaRepository;
        private readonly IManufacturerPublishingInfoRepository _publishingInfoRepository;

        public ManufacturerFactory(IManufacturerRepository manufacturerRepository,
            IManufacturerInfoRepository infoRepository, IManufacturerMetaRepository metaRepository,
            IManufacturerPublishingInfoRepository publishingInfoRepository)
        {
            _manufacturerRepository = manufacturerRepository;
            _infoRepository = infoRepository;
            _metaRepository = metaRepository;
            _publishingInfoRepository = publishingInfoRepository;
        }

        public async Task<Manufacturer> CreateManufacturerAsync(Guid manufacturerTemplateId, string name, string title,
            bool isPublished)
        {
            var manufacturerId = GuidGenerator.Create();
            
            var manufacturer = new Manufacturer(
                manufacturerId,
                manufacturerTemplateId
            );

            var manufacturerInfo = new ManufacturerInfo(manufacturerId);
            manufacturerInfo.SetName(name);
            manufacturerInfo.SetTitle(title);
            manufacturer.SetManufacturerInfo(await _infoRepository.InsertAsync(manufacturerInfo));

            var manufacturerMeta = new ManufacturerMeta(manufacturerId);
            manufacturer.SetManufacturerMeta(await _metaRepository.InsertAsync(manufacturerMeta));

            var publishingInfo = new ManufacturerPublishingInfo(manufacturerId);
            manufacturer.SetManufacturerPublishingInfo(await _publishingInfoRepository.InsertAsync(publishingInfo));

            return await _manufacturerRepository.InsertAsync(manufacturer);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Helpers;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommon.Seo
{
    public class UrlRecordService : DomainService, IUrlRecordService
    {
        private readonly IUrlRecordRepository _urlRecordRepository;

        public UrlRecordService(IUrlRecordRepository urlRecordRepository)
        {
            _urlRecordRepository = urlRecordRepository;
        }


        public async Task<string> ToSafeSlugAsync(string slug, Guid entityId, string entityTypeId)
        {
            var i = 2;
            while (true)
            {
                var urlRecord = await _urlRecordRepository.FindBySlugAsync(slug);
                if (urlRecord != null && !(urlRecord.EntityId == entityId && urlRecord.EntityTypeId == entityTypeId))
                {
                    slug = $"{slug}-{i}";
                    i++;
                }
                else
                {
                    break;
                }
            }

            return slug;
        }

        public async Task<UrlRecord> GetAsync(Guid entityId, string entityTypeId)
        {
            var urlRecord = await _urlRecordRepository.FindByEntityIdAsync(entityId);
            
            if(urlRecord != null && urlRecord.EntityTypeId == entityTypeId)
            {
                return urlRecord;
            }

            return null;
        }

        public async Task AddAsync(string name, string slug, Guid entityId, string entityTypeId)
        {
            var urlRecord = new UrlRecord(entityId, entityTypeId, name, slug);

            await _urlRecordRepository.InsertAsync(urlRecord);
        }

        public async Task UpdateAsync(string newName, string newSlug, Guid entityId, string entityTypeId)
        {
            var urlRecord = await _urlRecordRepository.FindByEntityIdAsync(entityId);

            if (urlRecord != null && urlRecord.EntityTypeId == entityTypeId)
            {
                urlRecord.SetName(newName);
                urlRecord.SetSlug(newSlug);
                
                await _urlRecordRepository.UpdateAsync(urlRecord);
            }
        }

        public async Task RemoveAsync(Guid entityId, string entityTypeId)
        {
            var urlRecord = await _urlRecordRepository.FindByEntityIdAsync(entityId);

            if (urlRecord != null && urlRecord.EntityTypeId == entityTypeId)
            {
                await _urlRecordRepository.DeleteAsync(urlRecord);
            }
        }
    }
}
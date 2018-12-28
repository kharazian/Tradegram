using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Seo
{
    public static class UrlRecordLookupServiceExtensions
    {
        public static async Task<TUrlRecord> GetByIdAsync<TUrlRecord>(
            this IUrlRecordLookupService<TUrlRecord> urlRecordLookupService, Guid id,
            CancellationToken cancellationToken = default)
            where TUrlRecord : class, IUrlRecord
        {
            var urlRecord = await urlRecordLookupService.FindByIdAsync(id, cancellationToken);

            if (urlRecord == null)
            {
                throw new EntityNotFoundException(typeof(TUrlRecord), id);
            }

            return urlRecord;
        }
        
        public static async Task<TUrlRecord> GetBySlugAsync<TUrlRecord>(
            this IUrlRecordLookupService<TUrlRecord> urlRecordLookupService, string slug,
            CancellationToken cancellationToken = default)
            where TUrlRecord : class, IUrlRecord
        {
            var urlRecord = await urlRecordLookupService.FindBySlugAsync(slug, cancellationToken);

            if (urlRecord == null)
            {
                throw new EntityNotFoundException(typeof(TUrlRecord), slug);
            }

            return urlRecord;
        }
    }
}
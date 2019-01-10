using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Common;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommon.Seo
{
    public interface IUrlRecordService : IDomainService
    {
        Task DeleteUrlRecordAsync(UrlRecord urlRecord, CancellationToken cancellationToken = default);

        Task InsertUrlRecordAsync(UrlRecord urlRecord, CancellationToken cancellationToken = default);

        Task UpdateUrlRecordAsync(UrlRecord urlRecord, CancellationToken cancellationToken = default);

        Task<string> GetActiveSlugAsync(Guid entityId, string entityTypeId,
            CancellationToken cancellationToken = default);

        Task SaveSlugAsync<T>(T entity, string slug, CancellationToken cancellationToken = default)
            where T : ISlugSupported;

        Task<string> GetSeNameAsync<T>(T entity, bool returnDefaultValue = true,
            CancellationToken cancellationToken = default) where T : ISlugSupported;

        Task<string> GetSeNameAsync(Guid entityId, string entityTypeId,
            CancellationToken cancellationToken = default);

        Task<string> GetSeNameAsync(string name, bool convertNonWesternChars, bool allowUnicodeCharsInUrls,
            CancellationToken cancellationToken = default);

        Task<string> ValidateSeNameAsync<T>(T entity, string seName, string name, bool ensureNotEmpty,
            CancellationToken cancellationToken = default) where T : ISlugSupported;

        Task<string> ValidateSeNameAsync(Guid entityId, string entityTypeId, string seName, string name,
            bool ensureNotEmpty, CancellationToken cancellationToken = default);
    }
}
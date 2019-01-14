using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommon.Seo
{
    public interface IUrlRecordService : IDomainService
    {
        Task<string> ToSafeSlugAsync(string slug, string entityTypeId);

        Task<UrlRecord> GetAsync(Guid entityId, string entityTypeId);

        Task AddAsync(string name, string slug, Guid entityId, string entityTypeId);

        Task UpdateAsync(string newName, string newSlug, Guid entityId, string entityTypeId);

        Task RemoveAsync(Guid entityId, string entityTypeId);
    }
}
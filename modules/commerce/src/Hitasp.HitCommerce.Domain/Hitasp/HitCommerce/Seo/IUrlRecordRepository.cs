using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Seo
{
    public interface IUrlRecordRepository : IBasicRepository<UrlRecord, Guid>
    {
        Task<List<UrlRecord>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
        
        Task<UrlRecord> FindBySlugAsync(string slug, CancellationToken cancellationToken = default);

        Task<UrlRecord> FindByEntityNameAsync(string entityName, CancellationToken cancellationToken = default);
        
        Task<UrlRecord> FindByEntityIdAsync(Guid entityId, CancellationToken cancellationToken = default);
        
        Task DeleteListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    }
}
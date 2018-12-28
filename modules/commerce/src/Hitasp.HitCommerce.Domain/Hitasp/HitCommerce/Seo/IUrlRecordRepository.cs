using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Seo;

namespace Hitasp.HitCommerce.Seo
{
    public interface IUrlRecordRepository : IUrlRecordRepositoryBase<UrlRecord>
    {
        Task<List<UrlRecord>> GetListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
        
        Task<UrlRecord> FindByEntityIdAsync(Guid entityId, CancellationToken cancellationToken = default);
        
        Task DeleteListAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    }
}
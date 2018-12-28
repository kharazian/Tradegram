using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hitasp.HitCommon.Seo
{
    public interface IUrlRecordLookupService<TUrlRecord>
        where TUrlRecord : class, IUrlRecord
    {
        Task<TUrlRecord> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<TUrlRecord> FindBySlugAsync(string slug, CancellationToken cancellationToken = default);
    }
}

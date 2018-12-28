using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hitasp.HitCommon.Seo
{
    public interface IExternalSeoLookupServiceProvider
    {
        Task<ISeoData> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<ISeoData> FindBySlugAsync(string slug, CancellationToken cancellationToken = default);
    }
}
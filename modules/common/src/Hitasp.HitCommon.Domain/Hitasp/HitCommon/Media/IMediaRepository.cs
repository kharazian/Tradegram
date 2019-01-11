using System;
using System.Threading;
using System.Threading.Tasks;
using Hitasp.HitCommon.Assets;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.Media
{
    public interface IMediaRepository<TMedia> : IBasicRepository<TMedia, Guid>
        where TMedia : AssetBase, IMedia
    {
        Task<TMedia> FindByUniqueName(string uniqueName, CancellationToken cancellationToken = default);
    }
}
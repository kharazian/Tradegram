using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.Medias
{
    public interface IMediaRepository<TMedia> : IBasicRepository<TMedia, Guid>
        where TMedia : Media, IMedia
    {
        Task<TMedia> FindByUniqueFileName(string uniqueFileName, CancellationToken cancellationToken = default);
    }
}
using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.Medias
{
    public interface IMediaRepository : IBasicRepository<Media, Guid>
    {
        Task<Media> FindByUniqueFileName(string uniqueFileName, CancellationToken cancellationToken = default);
    }
}
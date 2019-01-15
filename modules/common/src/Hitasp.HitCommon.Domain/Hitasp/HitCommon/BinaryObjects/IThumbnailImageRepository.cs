using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommon.BinaryObjects
{
    public interface IThumbnailImageRepository : IRepository<ThumbnailImage, Guid>
    {
        Task<byte[]> GetBytes(Guid id);
    }
}
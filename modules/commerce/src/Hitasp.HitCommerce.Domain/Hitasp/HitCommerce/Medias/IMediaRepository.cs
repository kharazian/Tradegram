using System;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Medias
{
    public interface IMediaRepository : IBasicRepository<Media, Guid>
    {
        Task<Media> GetByFileName(string fileName);
    }
}
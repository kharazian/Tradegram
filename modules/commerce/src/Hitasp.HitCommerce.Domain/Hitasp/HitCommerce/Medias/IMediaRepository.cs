using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MimeDetective;
using Volo.Abp.Domain.Repositories;

namespace Hitasp.HitCommerce.Medias
{
    public interface IMediaRepository : IBasicRepository<Media, Guid>
    {
        Task<Media> GetByFileName(string fileName);
    }
}
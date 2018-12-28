using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Hitasp.HitCommerce.Medias.Dtos;

namespace Hitasp.HitCommerce.Medias
{
    public interface IMediaAppService : IApplicationService
    {
        Task<MediaDto> GetMediaUrl(GetMediaUrlInputDto input);
    }
}
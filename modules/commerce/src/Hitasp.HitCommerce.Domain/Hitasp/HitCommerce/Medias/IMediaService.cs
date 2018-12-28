using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Hitasp.HitCommerce.Medias
{
    public interface IMediaService : IDomainService
    {
        Task<string> GetMediaUrl(Media media);

        Task<string> GetMediaUrl(string fileName);

        Task<string> GetThumbnailUrl(Media media);

        Task SaveMediaAsync(Stream mediaBinaryStream, string fileName, string rootDirectory, string caption = null);

        Task DeleteMediaAsync(Media media);

        Task DeleteMediaAsync(string fileName);
    }
}
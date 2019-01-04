using System.IO;
using System.Threading.Tasks;

namespace Hitasp.HitCommon.Medias
{
    public interface IMediaService
    {
        Task<string> GetMediaUrl(Media media);

        Task<string> GetMediaUrl(string uniqueFileName);

        Task<Media> SaveMediaAsync(Stream mediaBinaryStream, string fileName, string rootDirectory);

        Task DeleteMediaAsync(Media media);

        Task DeleteMediaAsync(string uniqueFileName);
    }
}
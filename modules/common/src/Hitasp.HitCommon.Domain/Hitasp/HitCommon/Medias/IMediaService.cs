using System.IO;
using System.Threading.Tasks;

namespace Hitasp.HitCommon.Medias
{
    public interface IMediaService<TMedia>
        where TMedia : Media, IMedia
    {
        Task<string> GetMediaUrl(TMedia media);

        Task<string> GetMediaUrl(string uniqueFileName);

        Task<TMedia> SaveMediaAsync(Stream mediaBinaryStream, string fileName, string rootDirectory);

        Task DeleteMediaAsync(TMedia media);

        Task DeleteMediaAsync(string uniqueFileName);
    }
}
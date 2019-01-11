using System.IO;
using System.Threading.Tasks;
using Hitasp.HitCommon.Assets;

namespace Hitasp.HitCommon.Media
{
    public interface IMediaService<TMedia> where TMedia : AssetBase, IMedia
    {
        Task<string> GetMediaUrl(TMedia media);

        Task<string> GetMediaUrl(string uniqueName);

        Task<TMedia> SaveMediaAsync(TMedia media, Stream mediaBinaryStream);

        Task DeleteMediaAsync(TMedia media);

        Task DeleteMediaAsync(string uniqueName);
    }
}
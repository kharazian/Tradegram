using Hitasp.HitCommon.Assets;

namespace Hitasp.HitCommon.Media
{
    public interface IMediaRepository<TMedia> : IAssetBaseRepository<TMedia>
        where TMedia : Asset, IMedia
    {
    }
}
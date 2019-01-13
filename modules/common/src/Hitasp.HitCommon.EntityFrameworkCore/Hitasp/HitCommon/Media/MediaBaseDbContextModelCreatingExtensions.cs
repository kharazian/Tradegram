using Hitasp.HitCommon.Assets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hitasp.HitCommon.Media
{
    public static class MediaBaseDbContextModelCreatingExtensions
    {
        public static void ConfigureAsMedia<TMedia>(this EntityTypeBuilder<TMedia> b)
            where TMedia : AssetBase, IMedia
        {
            b.ConfigureAsAsset();
            
            //Insert media(Images, Videos, Audios) generic configuration here
        }
    }
}
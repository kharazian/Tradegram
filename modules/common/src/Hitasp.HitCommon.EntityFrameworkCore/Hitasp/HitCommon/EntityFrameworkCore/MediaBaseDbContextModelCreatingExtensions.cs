using Hitasp.HitCommon.Assets;
using Hitasp.HitCommon.Media;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    public static class MediaBaseDbContextModelCreatingExtensions
    {
        public static void ConfigureAsMedia<TMedia>(this EntityTypeBuilder<TMedia> b)
            where TMedia : Asset, IMedia
        {
            b.ConfigureAsAsset();
            
            //Insert media(Images, Videos, Audios) generic configuration here
        }
    }
}
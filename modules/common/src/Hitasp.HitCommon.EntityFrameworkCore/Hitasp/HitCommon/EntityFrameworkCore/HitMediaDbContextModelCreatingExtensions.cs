using Hitasp.HitCommon.Medias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    public static class HitMediaDbContextModelCreatingExtensions
    {
        public static void ConfigureMedia<TMedia>(this EntityTypeBuilder<TMedia> b, ModelBuilderConfigurationOptions options)
            where TMedia : Media, IMedia
        {
            b.ToTable(options.TablePrefix + "Media", options.Schema);
            b.HasKey(x => x.Id);
            b.HasIndex(x => x.UniqueFileName).IsUnique();
            
            
            b.Property(x => x.FileExtension).HasColumnName(nameof(IMedia.FileExtension));
            b.Property(x => x.FileName).IsRequired().HasColumnName(nameof(IMedia.FileName));
            b.Property(x => x.RootDirectory).IsRequired().HasColumnName(nameof(IMedia.RootDirectory));
            b.Property(x => x.UniqueFileName).HasColumnName(nameof(IMedia.UniqueFileName));
            b.Property(x => x.MimeType).HasColumnName(nameof(IMedia.MimeType));
        }
    }
}
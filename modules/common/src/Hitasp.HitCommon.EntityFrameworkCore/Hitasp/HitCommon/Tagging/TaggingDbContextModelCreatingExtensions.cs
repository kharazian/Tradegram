using Hitasp.HitCommon.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommon.Tagging
{
    public static class TaggingDbContextModelCreatingExtensions
    {
        public static void ConfigureTagging(
            [NotNull] this ModelBuilder builder,
            [CanBeNull] string tablePrefix = HitCommonConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = HitCommonConsts.DefaultDbSchema)
        {
            Check.NotNull(builder, nameof(builder));

            if (tablePrefix == null)
            {
                tablePrefix = "";
            }


            builder.Entity<Tag>(b =>
            {
                b.ToTable(tablePrefix + "Tagging", schema);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.EntityTypeId);

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(Tag.Name));
                b.Property(x => x.Description).HasColumnName(nameof(Tag.Description));
                b.Property(x => x.UsageCount).HasColumnName(nameof(Tag.UsageCount));
                b.Property(x => x.EntityTypeId).IsRequired().HasColumnName(nameof(Tag.EntityTypeId));

                b.HasOne<EntityType>().WithMany().IsRequired().HasForeignKey(x => x.EntityTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
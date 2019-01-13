using Hitasp.HitCommon.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommon.Seo
{
    public static class UrlRecordDbContextModelCreatingExtensions
    {
        public static void ConfigureUrlRecord(
            [NotNull] this ModelBuilder builder,
            [CanBeNull] string tablePrefix = HitCommonConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = HitCommonConsts.DefaultDbSchema)
        {
            Check.NotNull(builder, nameof(builder));

            if (tablePrefix == null)
            {
                tablePrefix = "";
            }


            builder.Entity<UrlRecord>(b =>
            {
                b.ToTable(tablePrefix + "UrlRecords", schema);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.EntityTypeId);

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(UrlRecord.Name));
                b.Property(x => x.Slug).IsRequired().HasColumnName(nameof(UrlRecord.Slug));

                b.Property(x => x.EntityId).IsRequired().HasColumnName(nameof(UrlRecord.EntityId));
                b.Property(x => x.EntityTypeId).IsRequired().HasColumnName(nameof(UrlRecord.EntityTypeId));
                b.Property(x => x.IsActive).HasDefaultValue(true).HasColumnName(nameof(UrlRecord.IsActive));

                b.HasOne<EntityType>().WithMany().IsRequired().HasForeignKey(x => x.EntityTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
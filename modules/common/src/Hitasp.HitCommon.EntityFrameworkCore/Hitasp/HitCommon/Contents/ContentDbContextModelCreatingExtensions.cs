using Hitasp.HitCommon.Entities;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommon.Contents
{
    public static class ContentDbContextModelCreatingExtensions
    {
        public static void ConfigureContents(
            [NotNull] this ModelBuilder builder,
            [CanBeNull] string tablePrefix = HitCommonConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = HitCommonConsts.DefaultDbSchema)
        {
            Check.NotNull(builder, nameof(builder));

            if (tablePrefix == null)
            {
                tablePrefix = "";
            }
            
            builder.Entity<ContentOption>(b =>
            {
                b.ToTable(tablePrefix + "ContentOptions", schema);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.EntityTypeId);

                b.Property(x => x.EntityTypeId).IsRequired().HasColumnName(nameof(ContentAttributeGroup.EntityTypeId));
                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(ContentAttributeGroup.Name));

                b.HasOne<EntityType>().WithMany().IsRequired().HasForeignKey(x => x.EntityTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ContentAttributeGroup>(b =>
            {
                b.ToTable(tablePrefix + "ContentAttributeGroups", schema);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.EntityTypeId);

                b.Property(x => x.EntityTypeId).IsRequired().HasColumnName(nameof(ContentAttributeGroup.EntityTypeId));
                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(ContentAttributeGroup.Name));

                b.HasOne<EntityType>().WithMany().IsRequired().HasForeignKey(x => x.EntityTypeId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<ContentAttribute>(b =>
            {
                b.ToTable(tablePrefix + "ContentAttributes", schema);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.ContentAttributeGroupId);

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(ContentAttribute.Name));

                b.Property(x => x.ContentAttributeGroupId).IsRequired()
                    .HasColumnName(nameof(ContentAttribute.ContentAttributeGroupId));

                b.HasOne<ContentAttributeGroup>().WithMany().IsRequired().HasForeignKey(x => x.ContentAttributeGroupId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
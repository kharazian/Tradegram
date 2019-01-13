using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Hitasp.HitCommon.Entities
{
    public static class EntitiesDbContextModelCreatingExtensions
    {
        public static void ConfigureEntityTypes(
            [NotNull] this ModelBuilder builder,
            [CanBeNull] string tablePrefix = HitCommonConsts.DefaultDbTablePrefix,
            [CanBeNull] string schema = HitCommonConsts.DefaultDbSchema)
        {
            Check.NotNull(builder, nameof(builder));

            if (tablePrefix == null)
            {
                tablePrefix = "";
            }

            builder.Entity<EntityType>(b =>
            {
                b.ToTable(tablePrefix + "EntityTypes", schema);
                b.HasKey(x => x.Id);
                b.HasIndex(x => x.AreaName);

                b.Property(x => x.Name).IsRequired().HasColumnName(nameof(EntityType.Name));
                
                b.Property(x => x.AreaName).HasColumnName(nameof(EntityType.AreaName));
                b.Property(x => x.RoutingController).HasColumnName(nameof(EntityType.RoutingController));
                b.Property(x => x.RoutingAction).HasColumnName(nameof(EntityType.RoutingAction));

                b.Property(x => x.IsMenuable).HasColumnName(nameof(EntityType.IsMenuable));
            });
        }
    }
}
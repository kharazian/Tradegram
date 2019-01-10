using Hitasp.HitCommon.Entities;
using Hitasp.HitCommon.Media;
using Hitasp.HitCommon.Seo;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    [ConnectionStringName("HitCommon")]
    public class HitCommonDbContext : AbpDbContext<HitCommonDbContext>, IHitCommonDbContext
    {
        public static string TablePrefix { get; set; } = HitCommonConsts.DefaultDbTablePrefix;

        public static string Schema { get; set; } = HitCommonConsts.DefaultDbSchema;

        public DbSet<Image> Images { get; set; }
        
        public DbSet<UrlRecord> UrlRecords { get; set; }
        
        public DbSet<EntityType> EntityTypes { get; set; }

        public HitCommonDbContext(DbContextOptions<HitCommonDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureHitCommon(TablePrefix, Schema);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitSocial.EntityFrameworkCore
{
    [ConnectionStringName("HitSocial")]
    public class HitSocialDbContext : AbpDbContext<HitSocialDbContext>, IHitSocialDbContext
    {
        public static string TablePrefix { get; set; } = HitSocialConsts.DefaultDbTablePrefix;

        public static string Schema { get; set; } = HitSocialConsts.DefaultDbSchema;

        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public HitSocialDbContext(DbContextOptions<HitSocialDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureHitSocial(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
        }
    }
}
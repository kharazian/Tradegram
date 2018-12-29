using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Blogging.EntityFrameworkCore;
using Volo.Docs.EntityFrameworkCore;

namespace Hitasp.Tradegram.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class TradegramDbContext : AbpDbContext<TradegramDbContext>
    {
        public TradegramDbContext(DbContextOptions<TradegramDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureAuditLogging();
            modelBuilder.ConfigureBackgroundJobs();
            modelBuilder.ConfigureIdentity();
            modelBuilder.ConfigurePermissionManagement();
            modelBuilder.ConfigureSettingManagement();
            modelBuilder.ConfigureTenantManagement();
            modelBuilder.ConfigureDocs();
            modelBuilder.ConfigureBlogging();
        }
    }
}

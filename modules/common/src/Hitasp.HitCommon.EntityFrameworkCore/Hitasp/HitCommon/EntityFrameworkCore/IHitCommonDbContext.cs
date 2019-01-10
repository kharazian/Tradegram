using Hitasp.HitCommon.Entities;
using Hitasp.HitCommon.Media;
using Hitasp.HitCommon.Seo;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    [ConnectionStringName("HitCommon")]
    public interface IHitCommonDbContext : IEfCoreDbContext
    {
        DbSet<Image> Images { get; set; }
        
        DbSet<UrlRecord> UrlRecords { get; set; }
        
        DbSet<EntityType> EntityTypes { get; set; }
    }
}
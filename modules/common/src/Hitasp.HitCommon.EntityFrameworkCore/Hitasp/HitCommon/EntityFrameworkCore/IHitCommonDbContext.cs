using Hitasp.HitCommon.Medias;
using Hitasp.HitCommon.Models;
using Hitasp.HitCommon.Seo;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    [ConnectionStringName("HitCommon")]
    public interface IHitCommonDbContext : IEfCoreDbContext
    {
        DbSet<Media> Media { get; set; }
        
        DbSet<UrlRecord> UrlRecords { get; set; }
        
        DbSet<ContentItemType> ContentItemTypes { get; set; }
    }
}
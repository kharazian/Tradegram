using Hitasp.HitCommon.Contents;
using Hitasp.HitCommon.Entities;
using Hitasp.HitCommon.Media;
using Hitasp.HitCommon.Seo;
using Hitasp.HitCommon.Tagging;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    [ConnectionStringName("HitCommon")]
    public interface IHitCommonDbContext : IEfCoreDbContext
    {
        DbSet<Picture> Pictures { get; set; }
        
        DbSet<UrlRecord> UrlRecords { get; set; }
        
        DbSet<EntityType> EntityTypes { get; set; }
        
        DbSet<ContentAttribute> ContentAttributes { get; set; }
        
        DbSet<ContentAttributeGroup> ContentAttributeGroups { get; set; }
        
        DbSet<ContentOption> ContentOptions { get; set; }
        
        DbSet<Tag> Tags { get; set; }
    }
}
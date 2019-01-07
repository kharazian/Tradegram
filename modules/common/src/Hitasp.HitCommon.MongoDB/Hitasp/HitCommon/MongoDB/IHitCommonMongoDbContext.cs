using Hitasp.HitCommon.Medias;
using Hitasp.HitCommon.Models;
using Hitasp.HitCommon.Seo;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.MongoDB
{
    [ConnectionStringName("HitCommon")]
    public interface IHitCommonMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<Media> Media { get; }
        
        IMongoCollection<UrlRecord> UrlRecords { get; }
        
        IMongoCollection<ContentItemType> ContentItemType { get; }
    }
}

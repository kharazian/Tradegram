using Hitasp.HitCommon.Entities;
using Hitasp.HitCommon.Media;
using Hitasp.HitCommon.Seo;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.MongoDB
{
    [ConnectionStringName("HitCommon")]
    public interface IHitCommonMongoDbContext : IAbpMongoDbContext
    {
        IMongoCollection<Image> Images { get; }
        
        IMongoCollection<UrlRecord> UrlRecords { get; }
        
        IMongoCollection<EntityType> EntityTypes { get; }
    }
}

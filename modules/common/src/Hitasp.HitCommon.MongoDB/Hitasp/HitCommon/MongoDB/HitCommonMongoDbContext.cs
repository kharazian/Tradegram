using Hitasp.HitCommon.Medias;
using Hitasp.HitCommon.Seo;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.MongoDB
{
    [ConnectionStringName("HitCommon")]
    public class HitCommonMongoDbContext : AbpMongoDbContext, IHitCommonMongoDbContext
    {
        public static string CollectionPrefix { get; set; } = HitCommonConsts.DefaultDbTablePrefix;

        public IMongoCollection<Media> Media => Collection<Media>();
        
        public IMongoCollection<UrlRecord> UrlRecords => Collection<UrlRecord>();

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureHitCommon(options =>
            {
                options.CollectionPrefix = CollectionPrefix;
            });
        }
    }
}

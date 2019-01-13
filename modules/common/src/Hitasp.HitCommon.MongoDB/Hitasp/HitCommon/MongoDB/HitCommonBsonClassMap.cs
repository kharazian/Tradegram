using Hitasp.HitCommon.Contents;
using Hitasp.HitCommon.Entities;
using Hitasp.HitCommon.Media;
using Hitasp.HitCommon.Seo;
using Hitasp.HitCommon.Tagging;
using MongoDB.Bson.Serialization;
using Volo.Abp.Threading;

namespace Hitasp.HitCommon.MongoDB
{
    public static class HitCommonBsonClassMap
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                BsonClassMap.RegisterClassMap<Image>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<UrlRecord>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<EntityType>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<ContentAttribute>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<ContentAttributeGroup>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<ContentOption>(map =>
                {
                    map.AutoMap();
                });
                
                BsonClassMap.RegisterClassMap<Tag>(map =>
                {
                    map.AutoMap();
                });
            });
        }
    }
}
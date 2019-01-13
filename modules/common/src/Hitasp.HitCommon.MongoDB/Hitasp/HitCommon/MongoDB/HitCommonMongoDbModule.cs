using Hitasp.HitCommon.Contents;
using Hitasp.HitCommon.Entities;
using Hitasp.HitCommon.Media;
using Hitasp.HitCommon.Seo;
using Hitasp.HitCommon.Tagging;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommon.MongoDB
{
    [DependsOn(
        typeof(HitCommonDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class HitCommonMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            HitCommonBsonClassMap.Configure();
            
            context.Services.AddMongoDbContext<HitCommonMongoDbContext>(options =>
            {
                options.AddRepository<Picture, MongoMediaRepository<Picture>>();
                options.AddRepository<UrlRecord, MongoUrlRecordRepository>();
                options.AddRepository<EntityType, MongoEntityTypeRepository>();
                options.AddRepository<ContentAttribute, MongoContentAttributeRepository>();
                options.AddRepository<ContentAttributeGroup, MongoContentAttributeGroupRepository>();
                options.AddRepository<ContentOption, MongoContentOptionRepository>();
                options.AddRepository<Tag, MongoTagRepository>();
            });
        }
    }
}

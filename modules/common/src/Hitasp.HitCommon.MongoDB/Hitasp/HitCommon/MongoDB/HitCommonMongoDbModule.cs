using Hitasp.HitCommon.Media;
using Hitasp.HitCommon.Seo;
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
            context.Services.AddMongoDbContext<HitCommonMongoDbContext>(options =>
            {
                options.AddRepository<Image, MongoMediaRepository<Image>>();
            });
            
            context.Services.AddMongoDbContext<HitCommonMongoDbContext>(options =>
            {
                options.AddRepository<UrlRecord, MongoUrlRecordRepository>();
            });
        }
    }
}

using Hitasp.HitCommon.Contents;
using Hitasp.HitCommon.Entities;
using Hitasp.HitCommon.Media;
using Hitasp.HitCommon.Seo;
using Hitasp.HitCommon.Tagging;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hitasp.HitCommon.EntityFrameworkCore
{
    [DependsOn(
        typeof(HitCommonDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
        )]
    public class HitCommonEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<HitCommonDbContext>(options =>
            {
                options.AddRepository<Picture, EfCorePictureRepository>();
                options.AddRepository<UrlRecord, EfCoreUrlRecordRepository>();
                options.AddRepository<EntityType, EfCoreEntityTypeRepository>();
                options.AddRepository<ContentAttribute, EfCoreContentAttributeRepository>();
                options.AddRepository<ContentAttributeGroup, EfCoreContentAttributeGroupRepository>();
                options.AddRepository<ContentOption, EfCoreContentOptionRepository>();
                options.AddRepository<Tag, EfCoreTagRepository>();
            });
        }
    }
}

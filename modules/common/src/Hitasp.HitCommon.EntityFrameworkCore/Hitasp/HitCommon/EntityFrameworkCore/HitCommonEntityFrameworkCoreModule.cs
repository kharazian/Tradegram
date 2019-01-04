using Hitasp.HitCommon.Medias;
using Hitasp.HitCommon.Seo;
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
                options.AddRepository<Media, EfCoreMediaRepository>();
                options.AddRepository<UrlRecord, EfCoreUrlRecordRepository>();

            });
        }
    }
}

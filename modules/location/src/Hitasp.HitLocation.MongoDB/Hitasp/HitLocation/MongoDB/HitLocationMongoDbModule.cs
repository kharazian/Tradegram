using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Hitasp.HitLocation.MongoDB
{
    [DependsOn(
        typeof(HitLocationDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class HitLocationMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            HitLocationBsonClassMap.Configure();

            context.Services.AddMongoDbContext<HitLocationMongoDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
            });
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Hitasp.HitCommerce.Catalog.MongoDB
{
    [DependsOn(
        typeof(CatalogDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class CatalogMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            CatalogBsonClassMap.Configure();

            context.Services.AddMongoDbContext<CatalogMongoDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
            });
        }
    }
}

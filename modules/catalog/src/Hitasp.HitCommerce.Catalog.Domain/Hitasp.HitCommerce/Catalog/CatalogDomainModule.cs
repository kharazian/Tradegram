using Microsoft.Extensions.DependencyInjection;
using Hitasp.HitCommerce.Catalog.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Hitasp.HitCommerce.Catalog
{
    [DependsOn(
        typeof(CatalogDomainSharedModule)
        )]
    public class CatalogDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CatalogDomainModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Get<CatalogResource>().AddVirtualJson("/Hitasp.HitCommerce/Catalog/Localization/Domain");
            });

            Configure<ExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Catalog", typeof(CatalogResource));
            });
        }
    }
}

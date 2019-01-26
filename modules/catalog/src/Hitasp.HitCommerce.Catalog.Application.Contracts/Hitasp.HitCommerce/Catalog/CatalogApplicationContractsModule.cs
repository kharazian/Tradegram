using Hitasp.HitCommerce.Catalog.Localization;
using Volo.Abp.Application;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Hitasp.HitCommerce.Catalog
{
    [DependsOn(
        typeof(CatalogDomainSharedModule),
        typeof(AbpDddApplicationModule)
        )]
    public class CatalogApplicationContractsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<PermissionOptions>(options =>
            {
                options.DefinitionProviders.Add<CatalogPermissionDefinitionProvider>();
            });

            Configure<VirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CatalogApplicationContractsModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<CatalogResource>()
                    .AddVirtualJson("/Hitasp.HitCommerce/Catalog/Localization/ApplicationContracts");
            });
        }
    }
}

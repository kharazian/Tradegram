using Hitasp.HitCommerce.Catalog.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitCommerce.Catalog
{
    public class CatalogPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(CatalogPermissions.GroupName, L("Permission:Catalog"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CatalogResource>(name);
        }
    }
}
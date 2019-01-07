using Hitasp.HitLocation.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitLocation
{
    public class HitLocationPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(HitLocationPermissions.GroupName, L("Permission:HitLocation"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HitLocationResource>(name);
        }
    }
}
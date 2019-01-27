using Hitasp.HitSocial.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitSocial
{
    public class HitSocialPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(HitSocialPermissions.GroupName, L("Permission:HitSocial"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HitSocialResource>(name);
        }
    }
}
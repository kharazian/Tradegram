using Hitasp.Tradegram.Localization.Tradegram;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.Tradegram.Permissions
{
    public class TradegramPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(TradegramPermissions.GroupName);

            //Define your own permissions here. Examaple:
            //myGroup.AddPermission(TradegramPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<TradegramResource>(name);
        }
    }
}

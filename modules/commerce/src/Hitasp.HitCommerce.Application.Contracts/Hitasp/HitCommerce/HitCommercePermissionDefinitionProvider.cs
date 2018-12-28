using Hitasp.HitCommerce.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Hitasp.HitCommerce
{
    public class HitCommercePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var hitCoreGroup = context.AddGroup(HitCommercePermissions.GroupName, L("Permission:HitCommerceCore"));
            
            var addresses = hitCoreGroup.AddPermission(HitCommercePermissions.Addresses.Default, L("Permission:Addresses"));
            addresses.AddChild(HitCommercePermissions.Addresses.Update, L("Permission:Edit"));
            addresses.AddChild(HitCommercePermissions.Addresses.Delete, L("Permission:Delete"));
            addresses.AddChild(HitCommercePermissions.Addresses.Create, L("Permission:Create"));

            var customers = hitCoreGroup.AddPermission(HitCommercePermissions.Customers.Default, L("Permission:Customers"));
            customers.AddChild(HitCommercePermissions.Customers.Update, L("Permission:Edit"));
            customers.AddChild(HitCommercePermissions.Customers.Delete, L("Permission:Delete"));
            customers.AddChild(HitCommercePermissions.Customers.Create, L("Permission:Create"));

            var directions = hitCoreGroup.AddPermission(HitCommercePermissions.Directions.Default, L("Permission:Directions"));
            directions.AddChild(HitCommercePermissions.Directions.Update, L("Permission:Edit"));
            directions.AddChild(HitCommercePermissions.Directions.Delete, L("Permission:Delete"));
            directions.AddChild(HitCommercePermissions.Directions.Create, L("Permission:Create"));
            
            var medias = hitCoreGroup.AddPermission(HitCommercePermissions.Medias.Default, L("Permission:Medias"));
            medias.AddChild(HitCommercePermissions.Medias.Update, L("Permission:Edit"));
            medias.AddChild(HitCommercePermissions.Medias.Delete, L("Permission:Delete"));
            medias.AddChild(HitCommercePermissions.Medias.Create, L("Permission:Create"));
                        
            var userGroups = hitCoreGroup.AddPermission(HitCommercePermissions.UserGroups.Default, L("Permission:UserGroups"));
            userGroups.AddChild(HitCommercePermissions.UserGroups.Update, L("Permission:Edit"));
            userGroups.AddChild(HitCommercePermissions.UserGroups.Delete, L("Permission:Delete"));
            userGroups.AddChild(HitCommercePermissions.UserGroups.Create, L("Permission:Create"));
                        
            var vendors = hitCoreGroup.AddPermission(HitCommercePermissions.Vendors.Default, L("Permission:Vendors"));
            vendors.AddChild(HitCommercePermissions.Vendors.Update, L("Permission:Edit"));
            vendors.AddChild(HitCommercePermissions.Vendors.Delete, L("Permission:Delete"));
            vendors.AddChild(HitCommercePermissions.Vendors.Create, L("Permission:Create"));
                                    
            var widgets = hitCoreGroup.AddPermission(HitCommercePermissions.Widgets.Default, L("Permission:Widgets"));
            widgets.AddChild(HitCommercePermissions.Widgets.Update, L("Permission:Edit"));
            widgets.AddChild(HitCommercePermissions.Widgets.Delete, L("Permission:Delete"));
            widgets.AddChild(HitCommercePermissions.Widgets.Create, L("Permission:Create"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HitCommerceResource>(name);
        }
    }
}
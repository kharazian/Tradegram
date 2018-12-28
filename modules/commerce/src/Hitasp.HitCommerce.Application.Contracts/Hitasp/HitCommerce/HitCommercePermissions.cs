namespace Hitasp.HitCommerce
{
    public class HitCommercePermissions
    {
        public const string GroupName = "HitCommerce.Core";
        
        public static class Addresses
        {
            public const string Default = GroupName + ".Address";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";

        }

        public static class Customers
        {
            public const string Default = GroupName + ".Customer";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }

        public static class Directions
        {
            public const string Default = GroupName + ".Direction";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }
        
        public static class Medias
        {
            public const string Default = GroupName + ".Media";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }
        
        public static class UserGroups
        {
            public const string Default = GroupName + ".UserGroup";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }
        
        public static class Vendors
        {
            public const string Default = GroupName + ".Vendor";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }
        
        public static class Widgets
        {
            public const string Default = GroupName + ".Widget";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
        }

        public static string[] GetAll()
        {
            return new[]
            {
                GroupName,
                Addresses.Default,
                Addresses.Delete,
                Addresses.Update,
                Addresses.Create,
                Customers.Default,
                Customers.Delete,
                Customers.Update,
                Customers.Create,
                Directions.Default,
                Directions.Delete,
                Directions.Update,
                Directions.Create,
                Medias.Default,
                Medias.Delete,
                Medias.Update,
                Medias.Create,
                Vendors.Default,
                Vendors.Delete,
                Vendors.Update,
                Vendors.Create,
                Widgets.Default,
                Widgets.Delete,
                Widgets.Update,
                Widgets.Create,
                UserGroups.Default,
                UserGroups.Delete,
                UserGroups.Update,
                UserGroups.Create
            };
        }
    }
}
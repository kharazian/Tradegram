using System;

namespace Hitasp.Tradegram.Permissions
{
    public static class TradegramPermissions
    {
        public const string GroupName = "Tradegram";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public static string[] GetAll()
        {
            //Return an array of all permissions
            return Array.Empty<string>();
        }
    }
}
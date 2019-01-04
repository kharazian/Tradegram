namespace Hitasp.HitCommerce.Catalog
{
    public class CatalogPermissions
    {
        public const string GroupName = "Catalog";

        public static string[] GetAll()
        {
            return new[]
            {
                GroupName
            };
        }
    }
}
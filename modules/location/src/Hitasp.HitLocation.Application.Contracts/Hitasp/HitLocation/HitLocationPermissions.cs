namespace Hitasp.HitLocation
{
    public class HitLocationPermissions
    {
        public const string GroupName = "HitLocation";

        public static string[] GetAll()
        {
            return new[]
            {
                GroupName
            };
        }
    }
}
namespace Hitasp.HitSocial
{
    public class HitSocialPermissions
    {
        public const string GroupName = "HitSocial";

        public static string[] GetAll()
        {
            return new[]
            {
                GroupName
            };
        }
    }
}
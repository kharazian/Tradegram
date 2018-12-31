namespace Hitasp.HitCommerce.UserGroups.Dtos
{
    public class UserGroupWithDetailDto
    {
        public UserGroupDto UserGroup { get; set; }
        
        public long MembersCount { get; set; }
        
        public bool IsActive { get; set; }
    }
}
using System.Collections.Generic;
using Hitasp.HitCommerce.Customers.Dtos;

namespace Hitasp.HitCommerce.UserGroups.Dtos
{
    public class UserGroupWithDetailDto
    {
        public UserGroupDto UserGroup { get; set; }
        
        public long MembersCount { get; set; }
        
        public bool IsActive { get; set; }
        
        public List<CustomerInListDto> Members { get; set; }
    }
}
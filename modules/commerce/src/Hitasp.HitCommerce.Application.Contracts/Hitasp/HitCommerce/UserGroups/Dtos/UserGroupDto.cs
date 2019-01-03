using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.UserGroups.Dtos
{
    public class UserGroupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        
        public string Description { get; set; }
                
        public bool IsActive { get; set; }
    }
}
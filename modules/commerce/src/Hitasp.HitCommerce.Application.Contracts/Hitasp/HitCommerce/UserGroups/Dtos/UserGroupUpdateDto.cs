using System.ComponentModel.DataAnnotations;

namespace Hitasp.HitCommerce.UserGroups.Dtos
{
    public class UserGroupUpdateDto
    {
        [Required]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public bool IsActive { get; set; }
    }
}
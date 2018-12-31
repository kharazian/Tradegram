using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.UserGroups.Dtos
{
    public class UserGroupGetListInput : PagedAndSortedResultRequestDto
    {
        public string NameFilter { get; set; }
        
        public bool StatusFilter { get; set; }
    }
}
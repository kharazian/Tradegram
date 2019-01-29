using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Categories.Dtos
{
    public class CategoryGetListInput : PagedAndSortedResultRequestDto
    {
        public string CategoryName { get; set; }

        public bool ShowHidden { get; set; } = false;
    }
}
using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Directions.Dtos
{
    public class DistrictGetListInput : PagedAndSortedResultRequestDto
    {
        public Guid StateOrProvinceId { get; set; }
        
        public string NameFilter { get; set; }
    }
}
using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Directions.Dtos
{
    public class StateOrProvinceGetListInput : PagedAndSortedResultRequestDto
    {
        public Guid CountryId { get; set; }
        
        public string NameFilter { get; set; }
    }
}
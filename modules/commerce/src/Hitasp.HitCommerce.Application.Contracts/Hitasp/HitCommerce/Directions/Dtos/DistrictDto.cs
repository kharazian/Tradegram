using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Directions.Dtos
{
    public class DistrictDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        
        public string Type { get; set; }

        public string Location { get; set; }
    }
}
using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Directions.Dtos
{
    public class StateOrProvinceDto : EntityDto<Guid>
    {
        public Guid CountryId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
    }
}
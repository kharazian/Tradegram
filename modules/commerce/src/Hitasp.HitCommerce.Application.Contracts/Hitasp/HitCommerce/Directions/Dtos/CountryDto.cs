using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Directions.Dtos
{
    public class CountryDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Code3 { get; set; }

        public bool IsBillingEnabled { get; set; }

        public bool IsShippingEnabled { get; set; }

        public bool IsCityEnabled { get;  set; }

        public bool IsZipCodeEnabled { get;  set; }

        public bool IsDistrictEnabled { get;  set; }
    }
}
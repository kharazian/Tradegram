using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Dtos
{
    public class ManufacturerPageInfoDto : EntityDto<Guid>
    {
        public int PageSize { get; set; }

        public bool IsAllowCustomersToSelectPageSize { get; set; }
        
        public string PageSizeOptions { get; set; }
    }
}
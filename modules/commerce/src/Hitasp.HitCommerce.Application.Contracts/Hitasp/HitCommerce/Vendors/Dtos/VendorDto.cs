using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Vendors.Dtos
{
    public class VendorDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}
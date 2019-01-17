using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Catalog.Dtos
{
    public class ThumbnailImageDto: EntityDto<Guid>
    {
        public byte[] BinaryData { get; set; }
    }
}
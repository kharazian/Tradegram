using System;
using Volo.Abp.Application.Dtos;

namespace Hitasp.HitCommerce.Medias.Dtos
{
    public class MediaDto : EntityDto<Guid>
    {
        public string MediaUrl { get; set; }
        
        public string ThumbnailUrl { get; set; }
    }
}
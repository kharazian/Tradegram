using System;
using Volo.Abp.EventBus;

namespace Hitasp.HitCommon.Seo
{
    [EventName("Hitasp.HitCommon.Seo")]
    public class SeoEto : ISeoData
    {
        public Guid Id { get; set; }

        public Guid EntityId { get; set; }

        public string EntityName { get; set; }

        public string Slug { get; set; }

        public bool IsActive { get; set; }
    }
}

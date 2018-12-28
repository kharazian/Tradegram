using System;
using JetBrains.Annotations;

namespace Hitasp.HitCommon.Seo
{
    public class SeoData : ISeoData
    {
        public Guid Id { get; set; }

        public Guid EntityId { get; set; }

        public string EntityName { get; set; }

        public string Slug { get; set; }

        public bool IsActive { get; set; }

        public SeoData()
        {

        }

        public SeoData(
            Guid id,
            Guid entityId,
            [NotNull] string entityName,
            [NotNull] string slug,
            bool isActive = true)
        {
            Id = id;
            EntityId = entityId;
            EntityName = entityName;
            Slug = slug;
            IsActive = isActive;
        }
    }
}
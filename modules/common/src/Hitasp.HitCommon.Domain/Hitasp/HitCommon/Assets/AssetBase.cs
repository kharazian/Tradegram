using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Hitasp.HitCommon.Seo;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Localization;

namespace Hitasp.HitCommon.Assets
{
    public abstract class AssetBase : AuditedAggregateRoot<Guid>, IHasLanguage, ISlugSupported
    {
        protected AssetBase(
            Guid id,
            [NotNull] string name,
            [NotNull] string groupName,
            [NotNull] string slug,
            [NotNull] string extension
            )
        {
            Check.NotNullOrWhiteSpace(groupName, nameof(groupName));
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(slug, nameof(slug));
            Check.NotNullOrWhiteSpace(extension, nameof(extension));

            Id = id;
            GroupName = groupName;
            Name = name;
            Slug = slug;
            Extension = extension;
            
            UniqueName = $"{DateTime.Now.Ticks.ToString()}.{Extension}";
            TypeId = GetType().Name;
        }

        public string RelativeUrl { get; set; }

        public string Url { get; set; }

        public string TypeId { get; protected set; }

        public string GroupName { get; protected set; }

        public string Name { get; protected set; }

        public string Slug { get; protected set; }

        public string Extension { get; protected set; }

        public string LanguageCode { get; set; }

        public string UniqueName { get; private set; }

        public string SeoObjectType => GetType().Name;
        
 
        public override string ToString()
        {
            return Path.Combine(GroupName, UniqueName);
        }
    }
}

using System;
using System.IO;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Localization;

namespace Hitasp.HitCommon.Assets
{
    public abstract class AssetBase : AuditedAggregateRoot<Guid>
    {
        public string RelativeUrl { get; protected set; }

        public string Url { get; protected set; }

        public string GroupName { get; protected set; }

        public string Name { get; protected set; }

        public string Extension { get; protected set; }

        public string UniqueName { get; private set; }
        
        public string TypeId { get; private set; }

        
        protected AssetBase()
        {
            TypeId = GetType().Name;
            UniqueName = $"{DateTime.Now.Ticks.ToString()}.{Extension}";
        }
        
        public virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }

        public virtual void SetRelativeUrl([NotNull] string relativeUrl)
        {
            RelativeUrl = Check.NotNullOrWhiteSpace(relativeUrl, nameof(relativeUrl));
        }
        
        public virtual void SetUrl([NotNull] string url)
        {
            Url = Check.NotNullOrWhiteSpace(url, nameof(url));
        }
 
        public override string ToString()
        {
            return Path.Combine(GroupName, UniqueName);
        }
    }
}

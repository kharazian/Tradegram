using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommon.Assets
{
    public abstract class Asset : AuditedAggregateRoot<Guid>
    {
        public Guid? SpaceId { get; private set; }
        
        public string Url { get; private set; }

        public string FileName { get; private set; }

        public string Extension { get; private set; }
        
        public string MimeType { get; private set; }

        public string UniqueName { get; private set; }

        
        protected void SetSpace(Guid? spaceId)
        {
            if (spaceId == Guid.Empty || !spaceId.HasValue)
            {
                SpaceId = null;
            }

            if (SpaceId == spaceId)
            {
                return;
            }

            SpaceId = spaceId;
        }

        protected void SetFileName([NotNull] string name)
        {
            if (FileName == name)
            {
                return;
            }
            
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (name.Length >= AssetConsts.MaxFileNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {AssetConsts.MaxFileNameLength}");
            }

            FileName = name;
        }

        protected void SetMimeType([NotNull] string contentType)
        {
            if (MimeType == contentType)
            {
                return;
            }
            
            Check.NotNullOrWhiteSpace(contentType, nameof(contentType));

            if (contentType.Length >= AssetConsts.MaxMimeTypeLength)
            {
                throw new ArgumentException($"Content type can not be longer than {AssetConsts.MaxMimeTypeLength}");
            }

            MimeType = contentType;
        }

        protected void SetUrl([NotNull] string url)
        {
            if (Url == url)
            {
                return;
            }
            
            Check.NotNullOrWhiteSpace(url, nameof(url));
            
            if (url.Length >= AssetConsts.MaxUrlLength)
            {
                throw new ArgumentException($"Url can not be longer than {AssetConsts.MaxUrlLength}");
            }

            Url = url;
        }

        protected void SetExtension([NotNull] string extension)
        {
            if (Extension == extension)
            {
                return;
            }
            
            Check.NotNullOrWhiteSpace(extension, nameof(extension));

            Extension = extension;
        }
        


        protected void SetUniqueName([NotNull] string extension)
        {
            if (!UniqueName.IsNullOrWhiteSpace())
            {
                return;
            }
            
            Check.NotNullOrWhiteSpace(extension, nameof(extension));

            UniqueName = $"{Id}_{DateTime.Now.Ticks}.{extension}";
        }
 
        public override string ToString()
        {
            return UniqueName;
        }
    }
}

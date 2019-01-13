using Hitasp.HitCommon.Assets;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommon.Media
{
    public class Image : AssetBase, IMedia
    {
        public virtual string MimeType { get; protected set; }
        
        public virtual byte[] BinaryData { get; protected set; }
        
        public virtual int DisplayOrder { get; set; }

        protected Image()
        {
        }

        public Image(
            [NotNull] string name,
            [NotNull] string groupName,
            [NotNull] string mimeType,
            [NotNull] string extension)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(groupName, nameof(groupName));
            Check.NotNullOrWhiteSpace(mimeType, nameof(mimeType));
            Check.NotNullOrWhiteSpace(extension, nameof(extension));

            Name = name;
            GroupName = groupName;
            MimeType = mimeType;
            Extension = extension;
        }

        public virtual void SetBinaryData(byte[] binaryData)
        {
            BinaryData = binaryData;
        }
    }
}
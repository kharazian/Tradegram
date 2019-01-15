using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommon.BinaryObjects
{
    public class ThumbnailImage : CreationAuditedAggregateRoot<Guid>
    {
        public virtual string FileName { get; private set; }

        public virtual string MimeType { get; private set; }
        
        public virtual byte[] BinaryData { get; private set; }
        
        public virtual int DisplayOrder { get; private set; }

        private ThumbnailImage()
        {
        }

        public ThumbnailImage(
            [NotNull] string fileName,
            [NotNull] string mimeType,
            [NotNull] byte[] binaryData,
            int displayOrder = 0)
        {
            Check.NotNullOrWhiteSpace(fileName, nameof(fileName));
            Check.NotNullOrWhiteSpace(mimeType, nameof(mimeType));
            Check.NotNullOrEmpty(binaryData, nameof(binaryData));

            FileName = fileName;
            MimeType = mimeType;
            BinaryData = binaryData;
            DisplayOrder = displayOrder;
        }
    }
}
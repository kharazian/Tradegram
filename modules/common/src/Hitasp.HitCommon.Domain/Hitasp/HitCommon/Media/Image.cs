using System;
using Hitasp.HitCommon.Assets;
using JetBrains.Annotations;

namespace Hitasp.HitCommon.Media
{
    public class Image : AssetBase, IMedia
    {
        public string MimeType { get; set; }
        
        public byte[] BinaryData { get; set; }
        
        public int DisplayOrder { get; set; }

        public Image(
            Guid id,
            [NotNull] string name,
            [NotNull] string groupName,
            [NotNull] string slug,
            [NotNull] string extension) : base(id, name, groupName, slug, extension)
        {
        }
    }
}
using System;
using System.IO;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Medias
{
    public class Media: AggregateRoot<Guid>
    {
        public virtual string FileName { get; protected set; }
        
        public virtual string UniqueFileName { get; protected set; }
        
        public virtual string RootDirectory { get; protected set; }
        
        public virtual string MimeType { get; protected set; }
        
        public virtual string FileExtension { get; protected set; }

        protected Media()
        {
        }

        public Media(
            Guid id,
            [NotNull] string fileName,
            [NotNull] string rootDirectory,
            [NotNull] string mimeType,
            [NotNull] string fileExtension)
        {
            Id = id;
            FileName = fileName;
            RootDirectory = rootDirectory;
            MimeType = mimeType;
            FileExtension = fileExtension;
            
            UniqueFileName = DateTime.Now.Ticks + id.ToString() + "." + fileExtension;
        }

        public override string ToString()
        {
            return Path.Combine(RootDirectory, UniqueFileName);
        }
    }
}
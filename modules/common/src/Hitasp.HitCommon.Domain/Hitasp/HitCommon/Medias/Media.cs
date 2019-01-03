using System;
using System.IO;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Medias
{
    public abstract class Media: AggregateRoot<Guid>, IMedia
    {
        private readonly string _uniqueFileName;
        
        public string FileName { get; set; }
        
        public string UniqueFileName { get; protected set; }
        
        public string RootDirectory { get; set; }
        
        public string MimeType { get; set; }
        
        public string FileExtension { get; set; }

        protected Media()
        {
            _uniqueFileName = DateTime.Now.Ticks + "." + FileExtension;
        }

        protected Media(
            Guid id,
            [NotNull] string fileName,
            [NotNull] string rootDirectory,
            [NotNull] string fileExtension) : base(id)
        {
            FileName = fileName;
            RootDirectory = rootDirectory;
            FileExtension = fileExtension;
            
            UniqueFileName = _uniqueFileName;
        }

        public override string ToString()
        {
            return Path.Combine(RootDirectory, UniqueFileName);
        }
    }
}
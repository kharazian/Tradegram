using System;
using System.IO;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommon.Medias
{
    public abstract class Media: AggregateRoot<Guid>, IMedia
    {
        public string FileName { get; set; }
        
        public string UniqueFileName { get; }
        
        public string RootDirectory { get; set; }
        
        public string MimeType { get; set; }
        
        public string FileExtension { get; set; }

        protected Media()
        {
            UniqueFileName = DateTime.Now.Ticks + "." + FileExtension;
        }

        public override string ToString()
        {
            return Path.Combine(RootDirectory, UniqueFileName);
        }
    }
}
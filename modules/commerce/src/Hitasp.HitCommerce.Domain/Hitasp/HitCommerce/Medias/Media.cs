using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Medias
{
    public class Media : AggregateRoot<Guid>
    {
        private string _uniqueFileName;
        
        public virtual string Caption { get; protected set; }

        [NotNull]
        public virtual string FileName { get; protected set; }

        public virtual string UniqueFileName
        {
            get => _uniqueFileName;
            protected set => _uniqueFileName = value;
        }


        public virtual string RootDirectory { get; protected set; }

        public virtual string MimeType { get; set; }

        protected Media()
        {
            _uniqueFileName = Id.ToString();
        }

        public Media(Guid id, [NotNull] string fileName, string rootDirectory = null)
        {
            Id = id;
            FileName = fileName;
            RootDirectory = rootDirectory;
            
            _uniqueFileName = Id.ToString();
        }

        public virtual Media SetCaption([NotNull] string caption)
        {
            Caption = Check.NotNullOrWhiteSpace(caption, nameof(caption));
            return this;
        }
    }
}

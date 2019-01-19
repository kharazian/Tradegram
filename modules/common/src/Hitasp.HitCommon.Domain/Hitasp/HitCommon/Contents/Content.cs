using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommon.Contents
{
    public abstract class Content : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public string MetaTitle { get; private set; }

        public string MetaKeywords { get; private set; }

        public string MetaDescription { get; private set; }

        public bool IsPublished { get; private set; }


        protected void SetName([NotNull] string name)
        {
            if (Name == name)
            {
                return;
            }
            
            Check.NotNullOrWhiteSpace(name, nameof(name));

            if (name.Length >= ContentConsts.MaxNameLength)
            {
                throw new ArgumentException($"Name can not be longer than {ContentConsts.MaxNameLength}");
            }

            Name = name;
        }
        
        protected void SetDescription(string description)
        {
            if (Description == description)
            {
                return;
            }
            
            if (description.Length >= ContentConsts.MaxDescriptionLength)
            {
                throw new ArgumentException($"Name can not be longer than {ContentConsts.MaxDescriptionLength}");
            }

            Description = description;
        }

        protected void SetMetaData(string metaTitle, string metaKeywords, string metaDescription)
        {
            if (MetaTitle == metaTitle && MetaKeywords == metaKeywords && MetaDescription == metaDescription)
            {
                return;
            }
            
            if (metaTitle.Length >= ContentConsts.MaxMetaTitleLength)
            {
                throw new ArgumentException($"Meta Title can not be longer than {ContentConsts.MaxMetaTitleLength}");
            }
            
            if (metaKeywords.Length >= ContentConsts.MaxMetaKeywordsLength)
            {
                throw new ArgumentException($"Meta Keywords can not be longer than {ContentConsts.MaxMetaKeywordsLength}");
            }
            
            if (metaDescription.Length >= ContentConsts.MaxMetaDescriptionLength)
            {
                throw new ArgumentException($"Meta Description can not be longer than {ContentConsts.MaxMetaDescriptionLength}");
            }
            
            MetaTitle = metaTitle;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
        }

        protected void SetAsPublished(bool publish = true)
        {
            if (IsPublished == publish)
            {
                return;
            }

            IsPublished = publish;
        }
    }
}
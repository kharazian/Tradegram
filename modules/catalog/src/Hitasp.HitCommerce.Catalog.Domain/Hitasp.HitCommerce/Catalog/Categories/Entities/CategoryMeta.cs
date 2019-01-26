using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Categories.Entities
{
    public class CategoryMeta : Entity<Guid>
    {
        public virtual string MetaTitle { get; protected set; }

        public virtual string MetaKeywords { get; protected set; }

        public virtual string MetaDescription { get; protected set; }

        
        protected CategoryMeta()
        {
        }

        internal CategoryMeta(Guid categoryId) 
            : base(categoryId)
        {
        }

        public void SetMetaData(string metaTitle, string metaKeywords, string metaDescription)
        {
            if (MetaTitle == metaTitle && MetaKeywords == metaKeywords && MetaDescription == metaDescription)
            {
                return;
            }
            
            if (metaTitle.Length >= CategoryConsts.MaxMetaTitleLength)
            {
                throw new ArgumentException($"Meta Title can not be longer than {CategoryConsts.MaxMetaTitleLength}");
            }
            
            if (metaKeywords.Length >= CategoryConsts.MaxMetaKeywordsLength)
            {
                throw new ArgumentException($"Meta Keywords can not be longer than {CategoryConsts.MaxMetaKeywordsLength}");
            }
            
            if (metaDescription.Length >= CategoryConsts.MaxMetaDescriptionLength)
            {
                throw new ArgumentException($"Meta Description can not be longer than {CategoryConsts.MaxMetaDescriptionLength}");
            }
            
            MetaTitle = metaTitle;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
        }

    }
}
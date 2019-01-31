using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductMetaInfo : Entity<Guid>
    {
        public virtual string MetaTitle { get; protected set; }

        public virtual string MetaKeywords { get; protected set; }

        public virtual string MetaDescription { get; protected set; }

        protected ProductMetaInfo()
        {
        }

        internal ProductMetaInfo(Guid productId) : base(productId)
        {
        }
        
        public void SetMetaData(string metaTitle, string metaKeywords, string metaDescription)
        {
            if (MetaTitle == metaTitle &&
                MetaKeywords == metaKeywords &&
                MetaDescription == metaDescription)
            {
                return;
            }

            if (metaTitle.Length >= ProductConsts.MaxMetaTitleLength)
            {
                throw new ArgumentException($"Meta Title can not be longer than {ProductConsts.MaxMetaTitleLength}");
            }

            if (metaKeywords.Length >= ProductConsts.MaxMetaKeywordsLength)
            {
                throw new ArgumentException(
                    $"Meta Keywords can not be longer than {ProductConsts.MaxMetaKeywordsLength}");
            }

            if (metaDescription.Length >= ProductConsts.MaxMetaDescriptionLength)
            {
                throw new ArgumentException(
                    $"Meta Description can not be longer than {ProductConsts.MaxMetaDescriptionLength}");
            }

            MetaTitle = metaTitle;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
        }

    }
}
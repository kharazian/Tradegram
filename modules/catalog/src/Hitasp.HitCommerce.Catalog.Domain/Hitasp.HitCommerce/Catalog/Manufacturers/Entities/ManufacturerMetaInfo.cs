using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Entities
{
    public class ManufacturerMetaInfo : Entity<Guid>
    {
        public virtual string MetaTitle { get; protected set; }

        public virtual string MetaKeywords { get; protected set; }

        public virtual string MetaDescription { get; protected set; }


        protected ManufacturerMetaInfo()
        {
        }

        internal ManufacturerMetaInfo(Guid categoryId) : base(categoryId)
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

            if (metaTitle.Length >= ManufacturerConsts.MaxMetaTitleLength)
            {
                throw new ArgumentException(
                    $"Meta Title can not be longer than {ManufacturerConsts.MaxMetaTitleLength}");
            }

            if (metaKeywords.Length >= ManufacturerConsts.MaxMetaKeywordsLength)
            {
                throw new ArgumentException(
                    $"Meta Keywords can not be longer than {ManufacturerConsts.MaxMetaKeywordsLength}");
            }

            if (metaDescription.Length >= ManufacturerConsts.MaxMetaDescriptionLength)
            {
                throw new ArgumentException(
                    $"Meta Description can not be longer than {ManufacturerConsts.MaxMetaDescriptionLength}");
            }

            MetaTitle = metaTitle;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
        }
    }
}
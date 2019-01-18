using System;
using Hitasp.HitCommon.Contents;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public class Brand : ContentBase
    {
        public virtual Guid BrandTemplateId { get; protected set; }

        public virtual string PriceRanges { get; protected set; }

        protected Brand()
        {
        }

        public Brand(
            [NotNull] string name,
            [NotNull] string slug,
            [CanBeNull] string description,
            Guid pictureId,
            Guid brandTemplateId)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(slug, nameof(slug));

            Name = name;
            Slug = slug;
            Description = description;
            PictureId = pictureId;
            BrandTemplateId = brandTemplateId;
        }
        
        public virtual void SetTemplate(Guid templateId)
        {
            BrandTemplateId = templateId;
        }

        public virtual void SetPriceRange(string priceRanges)
        {
            PriceRanges = priceRanges;
        }

        public override void SetDisplayOrder(int displayOrder)
        {
            DisplayOrder = displayOrder;
        }
    }
}

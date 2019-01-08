using System;
using Hitasp.HitCommon.Models;
using JetBrains.Annotations;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public class Brand : ContentItem
    {
        public virtual Guid BrandTemplateId { get; protected set; }

        public virtual string PriceRanges { get; set; }

        protected Brand()
        {
        }

        public Brand(
            Guid id,
            [NotNull] string name,
            [NotNull] string slug,
            [CanBeNull] string description,
            Guid pictureId,
            Guid brandTemplateId)
            : base(id, name, slug, description)
        {
            PictureId = pictureId;
            BrandTemplateId = brandTemplateId;
        }
        
        public virtual void SetTemplate(Guid templateId)
        {
            BrandTemplateId = templateId;
        }
        

    }
}

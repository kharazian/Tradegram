﻿using System;
using Hitasp.HitCommon.Contents;
using JetBrains.Annotations;

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
            Guid imageId,
            Guid brandTemplateId)
            : base(name, slug, description)
        {
            ImageId = imageId;
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
    }
}

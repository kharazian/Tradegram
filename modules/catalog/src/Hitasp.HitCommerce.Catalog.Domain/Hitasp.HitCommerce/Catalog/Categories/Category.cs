﻿using System;
using Hitasp.HitCommon.Contents;
using JetBrains.Annotations;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class Category : ContentBase
    {
        public virtual Guid CategoryTemplateId { get; protected set; }
        
        public virtual Guid? ParentCategoryId { get; protected set; }

        public virtual bool ShowOnHomePage { get; protected set; }

        public virtual bool IncludeInTopMenu { get; protected set; }
        
        public virtual string PriceRanges { get; protected set; }
        

        protected Category()
        {
        }

        public Category(
            [NotNull] string name, 
            [NotNull] string slug,
            [CanBeNull] string description,
            Guid imageId,
            Guid categoryTemplateId,
            Guid? parentCategoryId = null)
            : base(name, slug, description)
        {
            ImageId = imageId;
            CategoryTemplateId = categoryTemplateId; 
            ParentCategoryId = parentCategoryId;
        }
        
        public virtual void SetTemplate(Guid templateId)
        {
            CategoryTemplateId = templateId;
        }
        
        public virtual void SetParentCategory(Guid parentCategoryId)
        {
            ParentCategoryId = parentCategoryId;
        }
        
        public virtual void SetAsMenuItem(bool includeInTopMenu = true)
        {
            IncludeInTopMenu = includeInTopMenu;
        }
        
        public virtual void SetAsHomePageItem(bool showOnHomePage = true)
        {
            ShowOnHomePage = showOnHomePage;
        }
        
        public virtual void SetPriceRange(string priceRanges)
        {
            PriceRanges = priceRanges;
        }
    }
}

using System;
using Hitasp.HitCommon.Models;
using JetBrains.Annotations;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class Category : ContentItem
    {
        public virtual Guid CategoryTemplateId { get; protected set; }
        
        public virtual Guid? ParentCategoryId { get; protected set; }

        public virtual string PriceRanges { get; set; }

        public virtual bool ShowOnHomePage { get; set; }

        public virtual bool IncludeInTopMenu { get; set; }
        
        protected Category()
        {
        }

        public Category(
            Guid id, 
            [NotNull] string name, 
            [NotNull] string slug,
            [CanBeNull] string description,
            Guid pictureId,
            Guid categoryTemplateId,
            Guid? parentCategoryId = null)
            : base(id, name, slug, description)
        {
            PictureId = pictureId;
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
    }
}

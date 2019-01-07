using System;
using System.Collections.ObjectModel;
using Hitasp.HitCommon.Models;
using JetBrains.Annotations;

namespace Hitasp.HitCommerce.Catalog.Categories
{
    public class Category : Content
    {
        public virtual string Description { get; protected set; }

        public virtual Guid? ParentId { get; protected set; }

        public virtual bool IncludeInMenu { get; set; }
        
        public virtual int DisplayOrder { get; set; }

        public virtual Guid ThumbnailImageId { get; set; }
        
        public virtual Collection<Category> Children { get; protected set; }

        protected Category()
        {
            Children = new Collection<Category>();
        }

        public Category(
            Guid id, 
            [NotNull] string name, 
            [NotNull] string slug,
            [CanBeNull] string description = null,
            Guid? parentId = null)
            : base(id, name, slug)
        {
            ParentId = parentId;
            Description = description;

            Children = new Collection<Category>();
        }
        
        public virtual void SetDescription(string description)
        {
            Description = description;
        }

        public virtual void SetParent(Guid parentId)
        {
            ParentId = parentId;
        }

        public virtual void SetThumbnailImage(Guid thumbnailImageId)
        {
            ThumbnailImageId = thumbnailImageId;
        }
    }
}

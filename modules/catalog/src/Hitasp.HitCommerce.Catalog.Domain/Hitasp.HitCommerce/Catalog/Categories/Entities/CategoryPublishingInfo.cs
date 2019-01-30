using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Categories.Entities
{
    public class CategoryPublishingInfo : Entity<Guid>
    {
        public virtual bool IsPublished { get; protected set; }

        public virtual bool ShowOnHomePage { get; protected set; }

        public virtual int DisplayOrder { get; protected set; }

        
        protected CategoryPublishingInfo()
        {
        }

        internal CategoryPublishingInfo(Guid categoryId) : base(categoryId)
        {
            SetAsPublished(false);
            SetAsHomePageItem(false);
            SetDisplayOrder();
        }
        
        public void SetAsPublished(bool publish = true)
        {
            if (IsPublished == publish)
            {
                return;
            }

            IsPublished = publish;
        }

        public void SetAsHomePageItem(bool showOnHomePage = true)
        {
            if (ShowOnHomePage == showOnHomePage)
            {
                return;
            }

            ShowOnHomePage = showOnHomePage;
        }

        public void SetDisplayOrder(int displayOrder = 0)
        {
            if (displayOrder > 0)
            {
                throw new ArgumentException($"{nameof(displayOrder)} can not be less than zero!");
            }

            if (DisplayOrder == displayOrder)
            {
                return;
            }

            DisplayOrder = displayOrder;
        }
    }
}
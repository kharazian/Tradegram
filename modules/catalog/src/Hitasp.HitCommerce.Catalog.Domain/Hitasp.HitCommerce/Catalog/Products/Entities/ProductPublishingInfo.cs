using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductPublishingInfo : Entity<Guid>
    {
        public virtual bool IsNew { get; protected set; }

        public virtual bool IsPublished { get; protected set; }

        public virtual DateTime? MarkAsNewStartDate { get; protected set; }

        public virtual DateTime? MarkAsNewEndDate { get; protected set; }

        public virtual DateTime? AvailableStartDate { get; protected set; }

        public virtual DateTime? AvailableEndDate { get; protected set; }

        public virtual bool ShowOnHomePage { get; protected set; }

        public virtual bool VisibleIndividually { get; protected set; }

        public virtual int DisplayOrder { get; protected set; }

        protected ProductPublishingInfo()
        {
        }

        internal ProductPublishingInfo(Guid productId) : base(productId)
        {
        }

        public void SetAsHomePageItem(bool showOnHomePage = true)
        {
            if (ShowOnHomePage == showOnHomePage)
            {
                return;
            }

            ShowOnHomePage = showOnHomePage;
        }

        public void DisplayIndividually(bool visibleIndividually = true)
        {
            if (VisibleIndividually == visibleIndividually)
            {
                return;
            }

            VisibleIndividually = visibleIndividually;
        }

        public void MarkAsNew(DateTime? startDate, DateTime? endDate)
        {
            if (IsNew && MarkAsNewStartDate == startDate && MarkAsNewEndDate == endDate)
            {
                return;
            }

            if (startDate.HasValue && startDate < DateTime.Now)
            {
                throw new ArgumentException("Can not set start date in the past!",
                    nameof(startDate));
            }

            if (endDate.HasValue && endDate <= startDate)
            {
                throw new ArgumentException("Can not set end date in the past of start date!",
                    nameof(endDate));
            }

            IsNew = true;
            MarkAsNewStartDate = startDate;
            MarkAsNewEndDate = endDate;
        }

        public void RemoveNewMarker()
        {
            IsNew = false;
            MarkAsNewStartDate = null;
            MarkAsNewEndDate = null;
        }

        public void SetPublishDate(DateTime startDate,
            DateTime? endDate)
        {
            if (IsPublished && AvailableStartDate == startDate && AvailableEndDate == endDate)
            {
                return;
            }

            if (startDate < DateTime.Now)
            {
                throw new ArgumentException("Can not set start date in the past!",
                    nameof(startDate));
            }

            if (endDate.HasValue && endDate <= startDate)
            {
                throw new ArgumentException("Can not set end date in the past of start date!",
                    nameof(endDate));
            }

            if (startDate <= DateTime.Now)
            {
                SetAsPublished();
            }
            else
            {
                SetAsPublished(false);
            }

            AvailableStartDate = startDate;
            AvailableEndDate = endDate;
        }

        private void SetAsPublished(bool publish = true)
        {
            if (IsPublished == publish)
            {
                return;
            }

            IsPublished = publish;
        }

        public void SetDisplayOrder(int displayOrder)
        {
            if (displayOrder < 0)
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
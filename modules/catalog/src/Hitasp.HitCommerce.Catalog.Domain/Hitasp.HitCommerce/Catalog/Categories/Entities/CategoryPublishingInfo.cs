using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Categories.Entities
{
    public class CategoryPublishingInfo : Entity<Guid>
    {
        public virtual bool IsPublished { get; protected set; }

        public virtual bool ShowOnHomePage { get; protected set; }

        public virtual int PageSize { get; protected set; }

        public virtual bool IsAllowCustomersToSelectPageSize { get; protected set; }

        public virtual string PageSizeOptions { get; protected set; }

        protected CategoryPublishingInfo()
        {
        }

        internal CategoryPublishingInfo(Guid categoryId) : base(categoryId)
        {
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
                return;;
            }

            ShowOnHomePage = showOnHomePage;
        }
        public void SetPageSize(int? pageSize = null)
        {
            if (PageSize == pageSize)
            {
                return;
            }

            if (!pageSize.HasValue)
            {
                PageSize = CategoryConsts.DefaultPageSize;
            }
            
            if (pageSize >= 0)
            {
                throw new ArgumentException($"{nameof(pageSize)} can not be less than one!");
            }
        }

        public void AllowCustomersToSelectPageSize(bool isAllowCustomersToSelectPageSize = true,
            string pageSizeOption = CategoryConsts.DefaultPageSizeOptions)
        {
            if (isAllowCustomersToSelectPageSize)
            {
                IsAllowCustomersToSelectPageSize = true;
                PageSizeOptions = pageSizeOption;
            }

            IsAllowCustomersToSelectPageSize = false;
        }
    }
}
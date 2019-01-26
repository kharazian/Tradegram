using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Entities
{
    public class ManufacturerPublishingInfo : Entity<Guid>
    {
        public virtual bool IsPublished { get; protected set; }

        public virtual bool ShowOnHomePage { get; protected set; }

        public virtual string PageSize { get; protected set; }

        public virtual bool IsAllowCustomersToSelectPageSize { get; protected set; }

        public virtual string PageSizeOptions { get; protected set; }

        protected ManufacturerPublishingInfo()
        {
        }

        internal ManufacturerPublishingInfo(Guid categoryId) : base(categoryId)
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

        public void SetPageSize(string pageSize)
        {
            if (pageSize.Length > ManufacturerConsts.MaxPageSizeLength)
            {
                throw new ArgumentException($"{nameof(pageSize)} can not be longer than {ManufacturerConsts.MaxPageSizeLength}");
            }
        }

        public void AllowCustomersToSelectPageSize(bool isAllowCustomersToSelectPageSize = true,
            string pageSizeOption = ManufacturerConsts.DefaultPageSizeOption)
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
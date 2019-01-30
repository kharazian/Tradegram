using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Categories.Entities
{
    public class CategoryPageInfo : Entity<Guid>
    {
        public virtual int PageSize { get; protected set; }

        public virtual bool IsAllowCustomersToSelectPageSize { get; protected set; }

        public virtual string PageSizeOptions { get; protected set; }

        protected CategoryPageInfo()
        {
            
        }
        
        internal CategoryPageInfo(Guid categoryId) : base(categoryId)
        {
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
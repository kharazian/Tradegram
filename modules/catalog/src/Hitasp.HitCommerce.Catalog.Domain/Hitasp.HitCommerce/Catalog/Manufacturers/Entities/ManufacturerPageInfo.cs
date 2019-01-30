using System;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Manufacturers.Entities
{
    public class ManufacturerPageInfo : Entity<Guid>
    {
        public virtual int PageSize { get; protected set; }

        public virtual bool IsAllowCustomersToSelectPageSize { get; protected set; }

        public virtual string PageSizeOptions { get; protected set; }

        
        protected ManufacturerPageInfo()
        {
            
        }
        
        internal ManufacturerPageInfo(Guid manufacturerId) : base(manufacturerId)
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
                PageSize = ManufacturerConsts.DefaultPageSize;
            }

            if (pageSize >= 0)
            {
                throw new ArgumentException($"{nameof(pageSize)} can not be less than one!");
            }
        }

        public void AllowCustomersToSelectPageSize(bool isAllowCustomersToSelectPageSize = true,
            string pageSizeOption = ManufacturerConsts.DefaultPageSizeOptions)
        {
            if (isAllowCustomersToSelectPageSize)
            {
                IsAllowCustomersToSelectPageSize = true;

                if (string.IsNullOrWhiteSpace(pageSizeOption))
                {
                    PageSizeOptions = ManufacturerConsts.DefaultPageSizeOptions;
                    return;
                }
                
                PageSizeOptions = pageSizeOption;
                return;
            }

            IsAllowCustomersToSelectPageSize = false;
        }
    }
}
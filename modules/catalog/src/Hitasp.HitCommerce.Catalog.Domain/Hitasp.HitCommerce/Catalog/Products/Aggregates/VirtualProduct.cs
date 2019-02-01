using System;
using System.Collections.Generic;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using JetBrains.Annotations;
using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public class VirtualProduct : Product
    {
        public virtual Guid? DownloadId { get; protected set; }

        public virtual bool UnlimitedDownloads { get; protected set; }

        public virtual int MaxNumberOfDownloads { get; protected set; }

        public virtual int? DownloadExpirationDays { get; protected set; }

        public virtual bool HasSampleDownload { get; protected set; }

        public virtual Guid? SampleDownloadId { get; protected set; }

        public virtual DownloadActivationType DownloadActivationType { get; set; }

        protected VirtualProduct()
        {
        }

        internal VirtualProduct(Guid id, [NotNull] string code, [NotNull] string name, decimal price)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));

            if (code.Length > ProductConsts.MaxCodeLength)
            {
                throw new ArgumentException($"Code can not be longer than {ProductConsts.MaxCodeLength}");
            }
            
            if (price < decimal.Zero)
            {
                throw new ArgumentException($"{nameof(price)} can not be less than 0.0!");
            }


            Id = id;
            Code = code;
            Price = price;

            SetName(name);

            ProductCategories = new HashSet<ProductCategory>();
            ProductManufacturers = new HashSet<ProductManufacturer>();
            ProductPictures = new HashSet<ProductPicture>();
            ProductSpecificationAttributes = new HashSet<ProductSpecificationAttribute>();
            ProductTags = new HashSet<ProductProductTag>();
            ProductProductAttributes = new HashSet<ProductProductAttribute>();
            ProductDiscounts = new HashSet<ProductDiscount>();
            ProductAttributeCombinations = new HashSet<ProductAttributeCombination>();
        }

        
    }
}
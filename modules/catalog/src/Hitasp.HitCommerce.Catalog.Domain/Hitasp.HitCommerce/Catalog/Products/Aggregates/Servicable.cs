using System;
using System.Collections.Generic;
using Hitasp.HitCommerce.Catalog.Products.Abstracts;
using Hitasp.HitCommerce.Catalog.Products.Entities;
using Hitasp.HitCommerce.Catalog.Products.Mapping;
using JetBrains.Annotations;

namespace Hitasp.HitCommerce.Catalog.Products.Aggregates
{
    public class Servicable : Product
    {
        public override void EnableBasePrice(bool basePriceEnabled, decimal basePriceAmount = decimal.Zero, int basePriceUnitId = 0,
            decimal basePriceBaseAmount = decimal.Zero, int basePriceBaseUnitId = 0)
        {
            BasePriceEnabled = false;
            ProductBasePrice = null;
        }

        #region Ctor

        protected Servicable()
        {
            ProductTags = new HashSet<ProductProductTag>();       
            RequiredProducts = new HashSet<RequiredProduct>();
            RelatedProducts = new HashSet<RelatedProduct>();
            CrossSellProducts = new HashSet<CrossSellProduct>();
            ProductCategories = new HashSet<ProductCategory>();
            ProductManufacturers = new HashSet<ProductManufacturer>();
            ProductPictures= new HashSet<ProductPicture>();
            ProductProductAttributes = new HashSet<ProductProductAttribute>();
            ProductSpecificationAttributes = new HashSet<ProductSpecificationAttribute>();
        }
        
        public Servicable(Guid id, [NotNull] string code, [NotNull] string name, [NotNull] string shortDescription, decimal price)
        {
            Id = id;
            SetCode(code);
            SetName(name);
            SetShortDescription(shortDescription);
            ChangePrice(price, false);
            EnableBasePrice(false);
        }

        #endregion
    }
}
﻿using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductOptionValue : Entity
    {
        public virtual Guid ProductId { get; protected set; }

        public virtual Guid OptionId { get; protected set; }

        public virtual string Value { get; protected set; }

        public virtual string DisplayType { get; set; }

        public virtual int SortIndex { get; set; }

        protected ProductOptionValue()
        {
        }

        public ProductOptionValue(Guid productId, Guid optionId)
        {
            ProductId = productId;
            OptionId = optionId;
        }

        public virtual void SetValue(string value)
        {
            Check.NotNullOrWhiteSpace(value, nameof(value));
            Value = value;
        }
        
        public override object[] GetKeys()
        {
            return new object[] {ProductId, OptionId};
        }
    }
}

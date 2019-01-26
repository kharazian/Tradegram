using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products.Entities
{
    public class ProductCode : Entity<Guid>
    {
        public virtual string Code { get; protected set; }
        
        protected ProductCode()
        {
        }

        internal ProductCode(Guid productId, [NotNull] string code) : base(productId)
        {
            Check.NotNullOrWhiteSpace(code, nameof(code));

            if (code.Length > ProductConsts.MaxCodeLength)
            {
                throw new ArgumentException($"Code can not be longer than {ProductConsts.MaxCodeLength}");
            }

            Code = code;
        }
    }
}
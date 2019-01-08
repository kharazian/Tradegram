using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Brands
{
    public class BrandTemplate : AggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string ViewPath { get; protected set; }

        public virtual int DisplayOrder { get; set; }

        protected BrandTemplate()
        {
        }

        public BrandTemplate(Guid id, [NotNull] string name, [NotNull] string viewPath)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(viewPath, nameof(viewPath));

            Id = id;
            Name = name;
            ViewPath = viewPath;
        }

        public virtual void SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;
        }
        
        public virtual void SetViewPath([NotNull] string viewPatch)
        {
            Check.NotNullOrWhiteSpace(viewPatch, nameof(viewPatch));

            ViewPath = viewPatch;
        }
    }
}
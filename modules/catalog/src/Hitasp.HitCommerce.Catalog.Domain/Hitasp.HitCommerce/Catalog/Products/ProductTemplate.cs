using System;
using System.Collections.ObjectModel;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Catalog.Products
{
    public class ProductTemplate : AggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        [NotNull]
        public virtual string ViewPath { get; protected set; }
        
        public virtual int DisplayOrder { get; set; }

        public virtual Collection<ProductTemplateAttribute> TemplateAttributes { get; protected set; }

        protected ProductTemplate()
        {
        }

        public ProductTemplate([NotNull] string name, [NotNull] string viewPath)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(viewPath, nameof(viewPath));

            Name = name;
            ViewPath = viewPath;
            
            TemplateAttributes = new Collection<ProductTemplateAttribute>();
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

        public virtual void AddAttribute(Guid attributeId)
        {
            TemplateAttributes.Add(new ProductTemplateAttribute(Id, attributeId));
        }
    }
}

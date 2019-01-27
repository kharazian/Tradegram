using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Catalog.Templates.Aggregates
{
    public class Template : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; protected set; }

        public string ViewPath { get; protected set; }

        public int DisplayOrder { get; protected set; }

        protected Template()
        {
        }

        public Template([NotNull] string name, [NotNull] string viewPath, int displayOrder = 0)
        {
            SetName(name);
            SetViewPath(viewPath);
            SetDisplayOrder(displayOrder);
        }

        public void SetName([NotNull] string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            Name = name;
        }
        
        public void SetViewPath([NotNull] string viewPatch)
        {
            Check.NotNullOrWhiteSpace(viewPatch, nameof(viewPatch));

            ViewPath = viewPatch;
        }
        
        public void SetDisplayOrder(int displayOrder)
        {
            if (displayOrder > 0)
            {
                throw new ArgumentException($"{nameof(displayOrder)} can not be less than zero!");
            }
            
            if (DisplayOrder == displayOrder)
            {
                return;
            }
            
            DisplayOrder = displayOrder;
        }
    }
}
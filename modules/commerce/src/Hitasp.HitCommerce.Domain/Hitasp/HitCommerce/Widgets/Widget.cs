using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hitasp.HitCommerce.Widgets
{
    public class Widget : CreationAuditedAggregateRoot<Guid>
    {
        public virtual string Code => Id.ToString();

        [NotNull]
        public virtual string Name { get; protected set; }

        public virtual string ViewComponentName { get; set; }

        public virtual string CreateUrl { get; set; }

        public virtual string EditUrl { get; set; }

        public virtual bool IsPublished { get; set; }

        protected Widget()
        {
        }

        public Widget([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }
        
        public virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }
    }
}

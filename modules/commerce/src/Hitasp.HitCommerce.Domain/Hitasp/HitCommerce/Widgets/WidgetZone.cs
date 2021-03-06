﻿using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Widgets
{
    public class WidgetZone : AggregateRoot<int>
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        public virtual string Description { get; set; }
        
        public WidgetZone([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }
        
        public virtual void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }

    }
}

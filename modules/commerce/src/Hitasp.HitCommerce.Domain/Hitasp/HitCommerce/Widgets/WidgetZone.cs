using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Hitasp.HitCommerce.Widgets
{
    public class WidgetZone : AggregateRoot<int>
    {
        [NotNull]
        public virtual string Name { get; protected set; }

        public virtual string Description { get; set; }
        
        public WidgetZone(int id, [NotNull] string name)
        {
            Id = id;
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        }
    }
}

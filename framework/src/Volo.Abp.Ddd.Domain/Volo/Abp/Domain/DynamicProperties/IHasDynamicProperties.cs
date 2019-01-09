using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.Domain.DynamicProperties
{
    public interface IHasDynamicProperties : IEntity
    {
        string ObjectType { get; }
        
        ICollection<DynamicObjectProperty> DynamicProperties { get; set; }
    }
}

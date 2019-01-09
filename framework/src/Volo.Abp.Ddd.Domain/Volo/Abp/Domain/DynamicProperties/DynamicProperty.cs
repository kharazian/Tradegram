using System;

namespace Volo.Abp.Domain.DynamicProperties
{
    public class DynamicProperty : ICloneable
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ObjectType { get; set; }

        public bool IsArray { get; set; }

        public bool IsDictionary { get; set; }

        public bool IsRequired { get; set; }
        
        public int? DisplayOrder { get; set; }

        public DynamicPropertyValueType ValueType { get; set; }

        public override string ToString()
        {
            return $"{Name ?? "n/a"}";
        }

        public virtual object Clone()
        {
            return MemberwiseClone() as DynamicProperty;
        }
    }
}
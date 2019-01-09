using System;

namespace Volo.Abp.Domain.DynamicProperties
{
    public class DynamicProperty : ICloneable
    {
        public string Name { get; set; }

        /// <summary>
        /// dynamic property description
        /// </summary>
        public string Description { get; set; }

        public string ObjectType { get; set; }

        /// <summary>
        /// Defines whether a property supports multiple values.
        /// </summary>
        public bool IsArray { get; set; }

        /// <summary>
        /// Dictionary has a predefined set of values. User can select one or more of them and cannot enter arbitrary values.
        /// </summary>
        public bool IsDictionary { get; set; }

        public bool IsRequired { get; set; }
        
        public int? DisplayOrder { get; set; }

        /// <summary>
        /// The storage property type 
        /// </summary>
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
using System;
using Volo.Abp.Domain.Values;

namespace Volo.Abp.Domain.DynamicProperties
{
    public class DynamicPropertyObjectValue : ValueObject<DynamicPropertyObjectValue>, ICloneable
    {
        public string ObjectType { get; set; }
        
        public string ObjectId { get; set; }

        public object Value { get; set; }

        public string ValueId { get; set; }
        
        public DynamicPropertyValueType ValueType { get; set; }

        public override string ToString()
        {
            return $"{(Value != null ? Value.ToString().Truncate(50) : "n/a")}";
        }

        public object Clone()
        {
            var result = MemberwiseClone() as DynamicPropertyObjectValue;

            if (Value is ICloneable cloneableValue)
            {
                result.Value = cloneableValue.Clone();
            }

            return result;
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Volo.Abp.Domain.DynamicProperties
{
    public class DynamicObjectProperty : DynamicProperty
    {
        public string ObjectId { get; set; }
        
        public ICollection<DynamicPropertyObjectValue> Values { get; set; }

        public override object Clone()
        {
            var result = base.Clone() as DynamicObjectProperty;

            if (Values != null)
            {
                result.Values = Values.Select(x => x.Clone() as DynamicPropertyObjectValue).ToArray();
            }

            return result;
        }

        public override string ToString()
        {
            var retVal = base.ToString();

            if (Values != null)
            {
                retVal += $"[{Values.Count}]";
            }

            return retVal;
        }
    }
}
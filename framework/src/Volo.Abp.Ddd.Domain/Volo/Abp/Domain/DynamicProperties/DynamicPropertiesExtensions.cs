using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Volo.Abp.Domain.DynamicProperties
{
    public static class DynamicPropertiesExtensions
    {
        public static T GetDynamicPropertyValue<T>(this IHasDynamicProperties owner, string propertyName,
            T defaultValue)
        {
            var result = defaultValue;

            var propValue = owner?.DynamicProperties?.Where(p => p.Name == propertyName && p.Values != null)
                .SelectMany(p => p.Values)
                .FirstOrDefault();

            if (propValue?.Value != null)
            {
                var jObject = propValue.Value as JObject;
                var dictItem = propValue.Value as DynamicPropertyDictionaryItem;

                if (jObject != null)
                {
                    dictItem = jObject.ToObject<DynamicPropertyDictionaryItem>();
                }

                var value = dictItem != null ? dictItem.Name : propValue.Value;
                result = (T) Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
            }

            return result;
        }
    }
}
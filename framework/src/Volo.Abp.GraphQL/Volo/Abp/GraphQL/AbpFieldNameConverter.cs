using System;
using GraphQL;
using GraphQL.Conversion;

namespace Volo.Abp.GraphQL
{
    public class AbpFieldNameConverter : IFieldNameConverter
    {
        private readonly IFieldNameConverter _defaultConverter = new CamelCaseFieldNameConverter();

        public string NameFor(string field, Type parentType)
        {
            var attributes = parentType?.GetCustomAttributes(typeof(GraphQLFieldNameAttribute), true);

            if (attributes == null)
            {
                return _defaultConverter.NameFor(field, parentType);
            }

            foreach(GraphQLFieldNameAttribute attribute in attributes)
            {
                if (attribute.Field == field)
                {
                    return attribute.Mapped;
                }
            }

            return _defaultConverter.NameFor(field, parentType);
        }
    }
}

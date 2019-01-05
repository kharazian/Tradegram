using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.DependencyInjection;
using Volo.Abp.GraphQL.Client.Extensions;

namespace Volo.Abp.GraphQL.Client
{
    public class EntityTypeQueryResourceBuilder : ITransientDependency
    {
        private readonly string _entityType;

        private readonly List<string> _keys = new List<string>();
        private readonly IDictionary<string, string> _queryFields = new Dictionary<string, string>();
        private readonly IDictionary<string, string> _nestedQueryFields = new Dictionary<string, string>();
        private readonly List<EntityTypeQueryResourceBuilder> _nested = new List<EntityTypeQueryResourceBuilder>();

        public EntityTypeQueryResourceBuilder(string entityType)
        {
            _entityType = entityType.ToGraphQLStringFormat();
        }

        public EntityTypeQueryResourceBuilder AddField(string name)
        {
            _keys.Add(name.ToGraphQLStringFormat());

            return this;
        }

        public EntityTypeQueryResourceBuilder WithNestedField(string fieldName)
        {
            var builder = new EntityTypeQueryResourceBuilder(fieldName);
            _nested.Add(builder);
            return builder;
        }

        public EntityTypeQueryResourceBuilder WithQueryField(string fieldName, string fieldValue)
        {
            _queryFields.Add(fieldName.ToGraphQLStringFormat(), fieldValue);
            return this;
        }

        public EntityTypeQueryResourceBuilder WithNestedQueryField(string fieldName, string fieldValue)
        {
            _nestedQueryFields.Add(fieldName.ToGraphQLStringFormat(), fieldValue);
            return this;
        }

        internal string Build()
        {
            var sb = new StringBuilder(_entityType);

            if (_queryFields.Count > 0 || _nestedQueryFields.Count > 0)
            {
                sb.Append("(where:{");

                for (var i = 0; i < _nestedQueryFields.Count; i++)
                {
                    var item = _nestedQueryFields.ElementAt(i);
                    sb.Append($"{item.Key}: {{ {item.Value} }}");

                    if (i < (_nestedQueryFields.Count - 1))
                    {
                        sb.Append(" ");
                    }
                }

                for (var i = 0; i < _queryFields.Count; i++)
                {
                    var item = _queryFields.ElementAt(i);
                    sb.Append($"{item.Key}: \"{item.Value}\"");

                    if (i < (_queryFields.Count - 1))
                    {
                        sb.Append(" ");
                    }
                }

                sb.Append("})");
            }

            sb.Append(" { ");

            sb.Append(" " + string.Join(" ", _keys) + " ");

            foreach (var item in _nested)
            {
                sb.Append(item.Build());
            }

            sb.Append(" }");

            return sb.ToString().Trim();
        }
    }
}

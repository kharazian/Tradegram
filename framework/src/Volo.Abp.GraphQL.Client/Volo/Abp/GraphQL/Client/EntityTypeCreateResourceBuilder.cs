using System.Collections.Generic;
using System.Text;
using Volo.Abp.DependencyInjection;
using Volo.Abp.GraphQL.Client.Extensions;

namespace Volo.Abp.GraphQL.Client
{
    public class EntityTypeCreateResourceBuilder : ITransientDependency
    {
        private readonly IDictionary<string, object> _values = new Dictionary<string, object>();

        private readonly List<EntityPartBuilder> _entityPartBuilders = new List<EntityPartBuilder>();

        private string EntityType { get; set; }

        public EntityTypeCreateResourceBuilder(string entityType)
        {
            EntityType = entityType;
        }

        public EntityPartBuilder WithContentPart(string contentPartName)
        {
            var builder = new EntityPartBuilder(contentPartName.ToGraphQLStringFormat());
            _entityPartBuilders.Add(builder);
            return builder;
        }

        public EntityTypeCreateResourceBuilder WithField(string key, object value)
        {
            _values.Add(key, value);

            return this;
        }

        internal string Build()
        {
            var sbo = new StringBuilder();

            sbo.AppendLine(EntityType.ToGraphQLStringFormat() + ": {");

            foreach (var value in _values)
            {
                var key = value.Key;

                if (value.Value is string)
                {
                    sbo.AppendLine($"{key}: \"{value.Value}\"");
                }
                else if (value.Value is bool b)
                {
                    sbo.AppendLine($"{key}: {b.ToString().ToLowerInvariant()}");
                }
                else {
                    sbo.AppendLine($"{key}: {value.Value}");
                }
            }

            for (var i = 0; i < _entityPartBuilders.Count; i++)
            {
                sbo.AppendLine(_entityPartBuilders[i].Build() + ((i == (_entityPartBuilders.Count - 1)) ? "" : ","));
            }
            
            sbo.AppendLine("}");

            return sbo.ToString();
        }
    }
}

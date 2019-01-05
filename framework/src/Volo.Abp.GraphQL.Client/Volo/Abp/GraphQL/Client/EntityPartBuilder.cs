using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.DependencyInjection;
using Volo.Abp.GraphQL.Client.Extensions;

namespace Volo.Abp.GraphQL.Client
{
    public class EntityPartBuilder : ITransientDependency
    {
        private readonly string _entityPartName;

        private readonly Dictionary<string, string> _keysWithValues = new Dictionary<string, string>();
        private readonly List<string> _keys = new List<string>();

        public EntityPartBuilder(string entityPartName)
        {
            _entityPartName = entityPartName;
        }

        public EntityPartBuilder AddField(string name, string value)
        {
            _keysWithValues.Add(name.ToGraphQLStringFormat(), value);

            return this;
        }

        public EntityPartBuilder AddField(string name)
        {
            _keys.Add(name);

            return this;
        }

        internal string Build()
        {
            var sb = new StringBuilder();
            sb.Append($"{_entityPartName}: {{ ");


            for (var i = 0; i < _keysWithValues.Count; i++)
            {
                var item = _keysWithValues.ElementAt(i);
                sb.Append($"{item.Key}: \"{item.Value}\"");

                if (i < (_keysWithValues.Count - 1))
                {
                    sb.Append(" ");
                }
            }

            foreach (var item in _keys)
            {
                sb.Append(item + " ");
            }

            sb.Append(" }");

            return sb.ToString();
        }
    }
}

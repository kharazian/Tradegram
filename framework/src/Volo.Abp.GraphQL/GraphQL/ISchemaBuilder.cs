using System.Threading.Tasks;
using GraphQL.Types;
using Microsoft.Extensions.Primitives;

namespace GraphQL
{
    public interface ISchemaBuilder
    {
        Task<IChangeToken> BuildAsync(ISchema schema);
    }
}

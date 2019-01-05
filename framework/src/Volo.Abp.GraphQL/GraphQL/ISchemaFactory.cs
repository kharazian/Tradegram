using System.Threading.Tasks;
using GraphQL.Types;

namespace GraphQL
{
    public interface ISchemaFactory
    {
        Task<ISchema> GetSchema();
    }
}

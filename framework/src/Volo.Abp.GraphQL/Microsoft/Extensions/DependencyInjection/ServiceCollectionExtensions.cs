using GraphQL.Queries;
using GraphQL.Types;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInputObjectGraphType<TObject, TObjectType>(this IServiceCollection services)
            where TObject : class 
            where TObjectType : InputObjectGraphType<TObject>
        {
            services.AddSingleton<TObjectType>();
            services.AddSingleton<InputObjectGraphType<TObject>, TObjectType>(s => s.GetRequiredService<TObjectType>());
            services.AddSingleton<IInputObjectGraphType, TObjectType>(s => s.GetRequiredService<TObjectType>());
        }

        public static void AddObjectGraphType<TInput, TInputType>(this IServiceCollection services)
            where TInput : class
            where TInputType : ObjectGraphType<TInput>
        {
            services.AddSingleton<TInputType>();
            services.AddSingleton<ObjectGraphType<TInput>, TInputType>(s => s.GetRequiredService<TInputType>());
            services.AddSingleton<IObjectGraphType, TInputType>(s => s.GetRequiredService<TInputType>());
        }

        public static void AddGraphQLFilterType<TObjectTypeToFilter, TFilterType>(this IServiceCollection services)
            where TObjectTypeToFilter : class
            where TFilterType : GraphQLFilter<TObjectTypeToFilter>
        {
            services.AddTransient<IGraphQLFilter<TObjectTypeToFilter>, TFilterType>();
        }
    }
}

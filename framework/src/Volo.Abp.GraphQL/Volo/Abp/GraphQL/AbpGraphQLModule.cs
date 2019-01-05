using GraphQL;
using GraphQL.Http;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace Volo.Abp.GraphQL
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    public class AbpGraphQLModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            context.Services.AddSingleton<IDocumentWriter, DocumentWriter>();
        }
    }
}
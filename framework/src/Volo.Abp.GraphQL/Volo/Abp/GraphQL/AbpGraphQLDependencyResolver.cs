using System;
using GraphQL;
using Microsoft.AspNetCore.Http;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.GraphQL
{
    internal class AbpGraphQLDependencyResolver : IDependencyResolver, ISingletonDependency
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AbpGraphQLDependencyResolver(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type type)
        {
            var serviceType = _httpContextAccessor.HttpContext.RequestServices.GetService(type);

            return serviceType ?? Activator.CreateInstance(type);
        }
    }
}

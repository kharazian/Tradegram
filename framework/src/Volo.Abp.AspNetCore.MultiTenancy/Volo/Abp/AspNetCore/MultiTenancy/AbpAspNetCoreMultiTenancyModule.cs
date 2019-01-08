﻿using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace Volo.Abp.AspNetCore.MultiTenancy
{
    [DependsOn(
        typeof(AbpMultiTenancyAbstractionsModule), 
        typeof(AbpAspNetCoreModule)
        )]
    public class AbpAspNetCoreMultiTenancyModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<TenantResolveOptions>(options =>
            {
                options.TenantResolvers.Add(new QueryStringTenantResolveContributor());
                options.TenantResolvers.Add(new RouteTenantResolveContributor());
                options.TenantResolvers.Add(new HeaderTenantResolveContributor());
                options.TenantResolvers.Add(new CookieTenantResolveContributor());
            });
        }
    }
}

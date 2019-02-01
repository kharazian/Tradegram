using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Volo.Abp;

namespace Hitasp.HitCommerce.Catalog.DemoApp
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<DemoAppModule>(options =>
            {
                options.UseAutofac();
            });

            return services.BuildServiceProviderFromFactory();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggingBuilder loggingBuilder)
        {
            loggingBuilder
                .AddConsole()
                .AddDebug()
                .AddSerilog(new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .WriteTo.File("Logs/logs.txt")
                    .CreateLogger()
                );

            app.InitializeApplication();
        }
    }
}

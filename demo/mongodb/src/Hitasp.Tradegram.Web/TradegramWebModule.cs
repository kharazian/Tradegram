using System.IO;
using System.Linq;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hitasp.Tradegram.MongoDb;
using Hitasp.Tradegram.Localization.Tradegram;
using Hitasp.Tradegram.Menus;
using Hitasp.Tradegram.Permissions;
using Swashbuckle.AspNetCore.Swagger;
using Volo.Abp;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Modularity;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc.UI;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Web;
using Volo.Abp.Localization;
using Volo.Abp.Localization.Resources.AbpValidation;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.Web;
using Volo.Abp.Threading;
using Volo.Abp.UI;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Hitasp.Tradegram
{
    [DependsOn(
        typeof(TradegramApplicationModule),
        typeof(TradegramMongoDbModule),
        typeof(AbpAutofacModule),
        typeof(AbpIdentityWebModule),
        typeof(AbpAccountWebModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule)
        )]
    public class TradegramWebModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(TradegramResource),
                    typeof(TradegramDomainModule).Assembly,
                    typeof(TradegramApplicationModule).Assembly,
                    typeof(TradegramWebModule).Assembly
                );
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureDatabaseServices(context.Services, configuration);
            ConfigureAutoMapper(context.Services);
            ConfigureVirtualFileSystem(context.Services, hostingEnvironment);
            ConfigureLocalizationServices(context.Services);
            ConfigureNavigationServices(context.Services);
            ConfigureAutoApiControllers(context.Services);
            ConfigureSwaggerServices(context.Services);
        }

        private static void ConfigureDatabaseServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<DbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = configuration.GetConnectionString("Default");
            });
        }

        private static void ConfigureAutoMapper(IServiceCollection services)
        {
            services.Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<TradegramWebAutoMapperProfile>();
            });
        }

        private static void ConfigureVirtualFileSystem(IServiceCollection services, IHostingEnvironment hostingEnvironment)
        {
            if (hostingEnvironment.IsDevelopment())
            {
                services.Configure<VirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPyhsical<TradegramDomainModule>(Path.Combine(hostingEnvironment.ContentRootPath, string.Format("..{0}Hitasp.Tradegram.Domain", Path.DirectorySeparatorChar)));
                });
            }
        }

        private static void ConfigureLocalizationServices(IServiceCollection services)
        {
            services.Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<TradegramResource>()
                    .AddBaseTypes(
                        typeof(AbpValidationResource),
                        typeof(AbpUiResource)
                    );

                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("pt-BR", "pt-BR", "Português"));
                options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            });
        }

        private static void ConfigureNavigationServices(IServiceCollection services)
        {
            services.Configure<NavigationOptions>(options =>
            {
                options.MenuContributors.Add(new TradegramMenuContributor());
            });
        }

        private static void ConfigureAutoApiControllers(IServiceCollection services)
        {
            services.Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(TradegramApplicationModule).Assembly);
            });
        }

        private static void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new Info { Title = "Tradegram API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseErrorPage();
            }

            app.UseVirtualFiles();
            app.UseAuthentication();
            app.UseAbpRequestLocalization();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tradegram API");
            });

            app.UseAuditing();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedDatabase(context);
        }

        private static void SeedDatabase(ApplicationInitializationContext context)
        {
            AsyncHelper.RunSync(async () =>
            {
                await context.ServiceProvider
                    .GetRequiredService<IIdentityDataSeeder>()
                    .SeedAsync(
                        "1q2w3E*",
                        IdentityPermissions.GetAll()
                            .Union(TradegramPermissions.GetAll())
                    );
            });
        }
    }
}

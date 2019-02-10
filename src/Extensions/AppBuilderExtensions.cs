using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.SwaggerUI;

using Walpy.VacancyApp.Server.Middleware;

namespace Walpy.VacancyApp.Server.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseAppErrorHandling(this IApplicationBuilder app, bool isDebug)
        {
            if (isDebug)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/web/Home/Error/{0}");
            }

            app.UseMiddleware<ApiErrorHandlingMiddleware>();
            return app;
        }

        public static IApplicationBuilder UseApiSpecification(this IApplicationBuilder app)
        {
            app.UseSwagger(options =>
            {
                options.RouteTemplate = CommonExtensions.OpenApiPathTemplate;
            });
            return app;
        }

        public static IApplicationBuilder UseDebugClient(this IApplicationBuilder app, IConfiguration config)
        {
            var version = config["version"];
            var openapi = config.GetSection(CommonExtensions.OpenApiSectionConfigKey);
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                    CommonExtensions.GetOpenApiPath(config),
                    $"{openapi["title"]} v{version}");
                options.RoutePrefix = "api/debug";
                options.DocExpansion(DocExpansion.List);
            });
            return app;
        }

        public static IApplicationBuilder UseAppDefaultFiles(this IApplicationBuilder app)
        {
            var options = new DefaultFilesOptions();
            options.RequestPath = "/web";
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index");
            app.UseDefaultFiles(options);
            return app;
        }

        public static IApplicationBuilder UseAppStaticFiles(this IApplicationBuilder app)
        {
            var options = new StaticFileOptions();
            options.RequestPath = "/web/static";
            app.UseStaticFiles(options);
            return app;
        }

        public static IApplicationBuilder UseAppMvc(this IApplicationBuilder app, IConfiguration config)
            => app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "api.openapi",
                    CommonExtensions.GetOpenApiPath(config)
                );
                routes.MapRoute(
                    "api.debug",
                    "api/debug/*"
                );
                routes.MapRoute(
                    "api",
                    "api/{controller}/*"
                );
                routes.MapRoute(
                    "web",
                    "web/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                    "default",
                    "{controller=IndexPage}/{action=Redirect}"
                );
            });
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.SwaggerUI;

using Walpy.VacancyApp.Server.Middleware;

namespace Walpy.VacancyApp.Server
{
    partial class Extensions
    {
        public const string OpenApiPathTemplate = "/api/{documentName}.json";

        public static IApplicationBuilder UseAppErrorHandling(this IApplicationBuilder app)
        {
            app.UseStatusCodePagesWithReExecute("/web/Home/Error/{0}");
            app.UseMiddleware<ApiErrorHandlingMiddleware>();
            return app;
        }

        public static IApplicationBuilder UseApiSpecification(this IApplicationBuilder app)
        {
            app.UseSwagger(options =>
            {
                options.RouteTemplate = OpenApiPathTemplate;
            });
            return app;
        }

        public static IApplicationBuilder UseDebugClient(this IApplicationBuilder app, IConfiguration config)
        {
            var version = config["version"];
            var openapi = config.GetSection(OpenApiSectionConfigKey);
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                    GetOpenApiPath(config),
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
                    GetOpenApiPath(config)
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
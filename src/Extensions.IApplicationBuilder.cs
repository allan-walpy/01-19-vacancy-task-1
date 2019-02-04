using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace App.Server
{
    partial class Extensions
    {
        public static IApplicationBuilder UseApiSpecification(this IApplicationBuilder app)
        {
            app.UseSwagger(options =>
            {
                //TODO:FIXME: magic string;
                options.RouteTemplate = "/api/{documentName}.json";
            });
            return app;
        }

        public static IApplicationBuilder UseDebugClient(this IApplicationBuilder app)
        {
            //TODO:FIXME: magic strings;
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                    "/api/scheme.json",
                    "vacancy.app v1.0.0");
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

        public static IApplicationBuilder UseAppMvc(this IApplicationBuilder app)
            => app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "api.scheme",
                    "api/scheme.json"
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
                    "web/{controller=Home}/{action=Index}"
                );
                routes.MapRoute(
                    "default",
                    "{controller=IndexPage}/{action=Redirect}"
                );
            });
    }
}
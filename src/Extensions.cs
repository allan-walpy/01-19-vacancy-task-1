using System;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

using App.Server.Services;

namespace App.Server
{
    public static class Extensions
    {
        public static IServiceCollection AddAppMvc(this IServiceCollection services)
            => services.AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .Services;

        public static IServiceCollection AddApiSpecification(this IServiceCollection services)
        {
            //TODO:FIXME: get rid of magic strings;
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("scheme",
                    new OpenApiInfo
                    {
                        Title = "vacancy.app",
                        Version = "1.0.0",
                        Description = "test task for managing vacancies",
                        Contact = new OpenApiContact
                        {
                            Name = "allan_walpy aka Andrey Lysenkov",
                            Url = new Uri("https://allan-walpy.github.io/"),
                            Email = "allanwalpy@gmail.com"
                        },
                        License = new OpenApiLicense
                        {
                            Name = "MIT",
                            Url = new Uri("https://github.com/allan-walpy/01-19-vacancy-task-1/blob/master/license")
                        }
                    });

                options.IncludeXmlComments(
                    Path.Join(Program.ExecutionPath, "server.xml"));
            });
            return services;
        }

        public static IServiceCollection AddAppDatabase(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseService, DatabaseService>();
            services.AddSingleton<IDatabaseVacancyService, DatabaseVacancyService>();
            services.AddSingleton<VacancyControllerService>();
            return services;
        }

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

        public static bool IsValidByRegexPattern(this string value, string pattern)
            => (new Regex(pattern)).IsMatch(value);
    }
}
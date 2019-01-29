using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace App.Server
{
    public static class Extensions
    {
        public static IServiceCollection AddAppMvc(this IServiceCollection services)
            => services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .Services;

        public static void AddApiSpecification(
            this IServiceCollection services,
            IConfiguration config)
        {
            //TODO:FIXME: get rid of magic strings;
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("scheme",
                    new OpenApiInfo
                    {
                        Title = "vacancy.app",
                        Version = "vacancy.app v1.0.0",
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

                options.IncludeXmlComments(Path.Join(
                    config["app:executionPath"],
                    "server.xml"));
            });
        }

        public static void UseApiSpecification(this IApplicationBuilder app)
        {
            app.UseSwagger(options =>
            {
                // TODO:FIXME: magic string;
                options.RouteTemplate = "/api/{documentName}.json";
            });
        }
    }
}
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using Walpy.VacancyApp.Server.Services;

namespace Walpy.VacancyApp.Server
{
    partial class Extensions
    {
        public static IServiceCollection AddAppMvc(this IServiceCollection services)
            => services.AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .Services;

        public static IServiceCollection AddApiSpecification(this IServiceCollection services, IConfiguration config)
        {
            //TODO:FIXME: get rid of magic strings;
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("scheme",
                    new OpenApiInfo
                    {
                        Title = "vacancy.app",
                        Version = config["version"],
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

        public static IServiceCollection ConfigureApiBehavior(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options => {
                options.InvalidModelStateResponseFactory = ApiBehaviorOnBadModel.OnInvalidModel;
            });

            return services;
        }

        public static IServiceCollection AddAppDatabase(this IServiceCollection services)
        {
            services.AddSingleton<IDatabaseService, DatabaseService>();
            services.AddSingleton<IDatabaseVacancyService, DatabaseVacancyService>();
            services.AddSingleton<IDatabaseOrganizationService, DatabaseOrganizationService>();
            services.AddSingleton<VacancyControllerService>();
            services.AddSingleton<SearchControllerService>();
            return services;
        }
    }
}
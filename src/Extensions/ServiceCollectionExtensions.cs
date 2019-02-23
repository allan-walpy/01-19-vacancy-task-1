using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

using Walpy.VacancyApp.Server.Services;

namespace Walpy.VacancyApp.Server.Extensions
{
    public static class ServiceCollectionExtensions
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
            var openapi = config.GetSection(CommonExtensions.OpenApiSectionConfigKey);
            var contact = config.GetSection(CommonExtensions.ContactsSectionConfigKey);
            var license = config.GetSection(CommonExtensions.LicenseSectionConfigKey);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(openapi["name"],
                    new OpenApiInfo
                    {
                        Title = openapi[nameof(OpenApiInfo.Title)],
                        Version = config["version"],
                        Description = openapi[nameof(OpenApiInfo.Description)],
                        Contact = new OpenApiContact
                        {
                            Name = contact[nameof(OpenApiContact.Name)],
                            Url = new Uri(contact[nameof(OpenApiContact.Url)]),
                            Email = contact[nameof(OpenApiContact.Email)]
                        },
                        License = new OpenApiLicense
                        {
                            Name = license[nameof(OpenApiLicense.Name)],
                            Url = new Uri(license[nameof(OpenApiLicense.Url)])
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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Walpy.VacancyApp.Server.Extensions;

namespace Walpy.VacancyApp.Server
{
    public class Startup
    {
        private IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiSpecification(_configuration);
            services.AddAppDatabase();
            services.AddAppMvc();
            services.ConfigureApiBehavior();
        }

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env)
        {
            var isDevelopment = env.IsDevelopment();

            app.UseAppErrorHandling(isDevelopment);

            app.UseApiSpecification();

            if (isDevelopment
                || _configuration.GetValue<bool>(Program.UseDebugClientConfigKey))
            {
                app.UseDebugClient(_configuration);
            }

            app.UseAppDefaultFiles();
            app.UseAppStaticFiles();

            app.UseAppMvc(_configuration);
        }
    }
}

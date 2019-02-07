using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Server
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
            services.AddApiSpecification();
            services.AddAppDatabase();
            services.AddAppMvc();
            services.ConfigureApiBehavior();
        }

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env)
        {
            var isDevelopment = env.IsDevelopment();

            if (isDevelopment)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseAppErrorHandling();
            }

            app.UseApiSpecification();

            if (isDevelopment)
            {
                app.UseDebugClient(_configuration);
            }

            app.UseAppDefaultFiles();
            app.UseAppStaticFiles();

            app.UseAppMvc();
        }
    }
}

using Microsoft.Extensions.Configuration;

namespace Walpy.VacancyApp.Server.Services
{
    public sealed class DemoService
    {
        private IConfiguration Configuration { get; }
        public DemoService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
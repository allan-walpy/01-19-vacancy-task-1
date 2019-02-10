using Microsoft.AspNetCore.Hosting;

namespace Walpy.VacancyApp.Server
{
    partial class Extensions
    {
        public static IWebHostBuilder DetectEnviroment(this IWebHostBuilder hostBuilder)
        {
            var enviroment = EnvironmentName.Production;
#if DEBUG
            enviroment = EnvironmentName.Development;
#endif
#if PRODUCTION
            enviroment = EnvironmentName.Production;
#endif
            hostBuilder.UseEnvironment(enviroment);
            return hostBuilder;
        }
    }
}
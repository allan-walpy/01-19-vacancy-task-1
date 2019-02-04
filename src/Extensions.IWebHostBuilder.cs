using Microsoft.AspNetCore.Hosting;

namespace App.Server
{
    partial class Extensions
    {
        public static IWebHostBuilder DetectEnviroment(this IWebHostBuilder hostBuilder)
        {
            var enviroment = EnvironmentName.Staging;
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
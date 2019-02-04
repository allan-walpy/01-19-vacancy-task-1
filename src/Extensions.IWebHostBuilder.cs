using Microsoft.AspNetCore.Hosting;

namespace App.Server
{
    partial class Extensions
    {
        public static IWebHostBuilder DetectEnviroment(this IWebHostBuilder hostBuilder)
        {
            hostBuilder.UseEnvironment(EnvironmentName.Staging);
#if DEBUG
            hostBuilder.UseEnvironment(EnvironmentName.Development);
#endif
#if PRODUCTION
            hostBuilder.UseEnvironment(EnvironmentName.Production);
#endif
            return hostBuilder;
        }
    }
}
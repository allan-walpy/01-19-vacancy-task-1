using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace App.Server
{
    public class Program
    {
        public const string PrivateConfigFile = "appsettings.private.json";
        public const string IsDevEnviromentConfigKey = "debug";
        public static string ExecutionPath
            => Path.GetDirectoryName(typeof(Program).Assembly.Location);

        public static long CurrentTimestamp
            => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder DetectEnviroment(IWebHostBuilder hostBuilder)
        {
#if DEBUG
            return hostBuilder.UseEnvironment(EnvironmentName.Development);
#endif
#if PRODUCTION
            return hostBuilder.UseEnvironment(EnvironmentName.Production);
#endif
            var debugSetting = hostBuilder.GetSetting(IsDevEnviromentConfigKey);
            var isDebug = Boolean.Parse(debugSetting);

            if (isDebug)
            {
                return hostBuilder.UseEnvironment(EnvironmentName.Development);
            }

            return hostBuilder.UseEnvironment(EnvironmentName.Production);
        }

        public static IWebHostBuilder CreateWebHostBuilder(params string[] args)
        {
            var result = WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile(PrivateConfigFile,
                        optional: false,
                        reloadOnChange: true);
                })
                .UseStartup<Startup>();

            return DetectEnviroment(result);
        }
    }
}

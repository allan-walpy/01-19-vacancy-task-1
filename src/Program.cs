using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Walpy.VacancyApp.Server
{
    public static class Program
    {
        public const string EnviromentConfigPrefix = "VACANCY_APP_";
        public const string CommandLineArgsConfigPrefix = "--config_";
        public const char CommandLineArgsConfigValueSeparator = '=';
        public const string PrivateConfigFile = "appsettings.private.json";
        public const string LocalizationConfigFile = "appsettings.language.ru-RU.json";
        public const string IsDevEnviromentConfigKey = "debug";

        public static string ExecutionPath
            => Path.GetDirectoryName(typeof(Program).Assembly.Location);

        public static long CurrentTimestamp
            => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(params string[] args)
            => WebHost
                .CreateDefaultBuilder(args)
                .DetectEnviroment()
                .ConfigureAppConfiguration(configBuilder =>
                {
                    configBuilder.AddJsonFile(
                        PrivateConfigFile,
                        optional: false,
                        reloadOnChange: false);

                    configBuilder.AddJsonFile(
                        LocalizationConfigFile,
                        optional: false,
                        reloadOnChange: true
                    );

                    configBuilder.AddEnvironmentVariables(EnviromentConfigPrefix);
                    if (args.Length > 0)
                    {
                        configBuilder.AddCommandLine((argsContext) =>
                        {
                            argsContext.AddAsConfiguraionTo(configBuilder);
                        });
                    }
                })
                .UseStartup<Startup>();
    }
}

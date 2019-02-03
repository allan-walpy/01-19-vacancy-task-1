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
        public static string ExecutionPath
            => Path.GetDirectoryName(typeof(Program).Assembly.Location);

        public static long CurrentTimestamp
            => DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(params string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                {

                    config.AddJsonFile($"{ExecutionPath}/{PrivateConfigFile}",
                        optional: false,
                        reloadOnChange: true);
                })
                .UseStartup<Startup>();
    }
}

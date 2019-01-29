using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace App.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                // TODO:FIXME: to method;
                .ConfigureAppConfiguration((config) =>
                {
                    //TODO:FIXME: magic string;
                    config.AddInMemoryCollection(
                        new Dictionary<string, string>
                        {
                            {
                                "app:executionPath",
                                Path.GetDirectoryName(typeof(Program).Assembly.Location)
                            }
                        }
                    );
                })
                .UseStartup<Startup>();
    }
}

using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;

namespace App.Server.Test.Instance
{
    public class AppInstance : IDisposable
    {
        public const string DbInMemmoryConfigKey = "database:test";

        public int Port { get; }
        protected IWebHost App { get; }

        public AppInstance()
        {
            Port = PortGenerator.GetPort();
            App = ConfigureApp().Build();
            App.RunAsync();
        }

        private IWebHostBuilder ConfigureApp()
        {
            var appBuilder = Program.CreateWebHostBuilder()
                .SuppressStatusMessages(true)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                })
                .ConfigureAppConfiguration((configBuilder) =>
                {
                    configBuilder.AddInMemoryCollection(
                        new Dictionary<string, string>
                        {
                            {
                                DbInMemmoryConfigKey, "true"
                            },
                            {
                                Program.IsDevEnviromentConfigKey, "false"
                            }
                        }
                    );

                    //? disable `ReloadOnChange`, as it may trigger exception:
                    //?  `System.IO.IOException : The configured user limit (128) on the number of inotify instances has been reached.`
                    //? om linux systems;
                    foreach (var configSource in configBuilder.Sources)
                    {
                        var configFileSource = configSource as JsonConfigurationSource;
                        if (configFileSource != null)
                        {
                            configFileSource.ReloadOnChange = false;
                        }
                    }
                })
                .ConfigureKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, Port);
                });

            return appBuilder;
        }

        public void Dispose()
        {
            App.StopAsync().Wait();
        }
    }
}
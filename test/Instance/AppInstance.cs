using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging;

namespace Walpy.VacancyApp.Server.Test.Instance
{
    public class AppInstance : IDisposable
    {
        public const string DbInMemmoryConfigKey = "database:test";

        private static readonly Dictionary<string, string> DefaultAppConfig
            = new Dictionary<string, string>
            {
                {
                    DbInMemmoryConfigKey, "true"
                },
                {
                    Program.IsDevEnviromentConfigKey, "false"
                }
            };

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
                    configBuilder.AddInMemoryCollection(DefaultAppConfig);
                    DisableReloadOnChange(configBuilder.Sources);
                })
                .ConfigureKestrel(options =>
                {
                    options.Listen(IPAddress.Loopback, Port);
                });

            return appBuilder;
        }

        private void DisableReloadOnChange(IList<IConfigurationSource> sources)
        {
            foreach (var source in sources)
            {
                var configFileSource = source as JsonConfigurationSource;
                if (configFileSource != null)
                {
                    configFileSource.ReloadOnChange = false;
                }
            }
        }

        public void Dispose()
        {
            App.StopAsync().Wait();
        }
    }
}
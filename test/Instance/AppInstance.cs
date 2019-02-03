using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

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
                })
                .ConfigureKestrel(options => {
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
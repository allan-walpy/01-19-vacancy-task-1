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
        public const string ListenUrlTemplate = "https://localhost:{0}/";

        public int Port { get; }

        protected IWebHost App { get; }

        public AppInstance()
        {
            Port = PortGenerator.GetPort();
            App = ConfigureApp().Build();
            App.RunAsync();
        }

        private string GetListenUrl()
            => String.Format(
                ListenUrlTemplate,
                Port);

        private IWebHostBuilder ConfigureApp()
        {
            var appBuilder = Program.CreateWebHostBuilder()
                .ConfigureAppConfiguration((configBuilder) =>
                {
                    configBuilder.AddInMemoryCollection(
                        new Dictionary<string, string>
                        {
                            {
                                DbInMemmoryConfigKey, "true"
                            }
                        }
                    );
                })
                .UseKestrel(options => {
                    options.Listen(IPAddress.Loopback, Port);
                });
                //!tmp;
                //? Suppress start status messages;
                //.UseSetting(WebHostDefaults.SuppressStatusMessagesKey, "True");
            return appBuilder;
        }

        public void Dispose()
        {
            App.StopAsync().Wait();
        }
    }
}
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Falcon
{
    public sealed class ServiceHost : IDisposable
    {
        private readonly IWebHost _webHost;

        internal ServiceHost(IWebHost webHost)
        {
            _webHost = webHost;
        }

        public void Run()
        {
            _webHost.Run();
        }

        public void Start()
        {
            _webHost.Start();
        }

        public void Dispose()
        {
            _webHost.Dispose();
        }

        internal class Startup
        {
            public Startup(IHostingEnvironment env)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                    .AddEnvironmentVariables();
                Configuration = builder.Build();
            }

            public IConfigurationRoot Configuration { get; }

            public void ConfigureServices(IServiceCollection services)
            {

            }

            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {

            }
        }
    }
}
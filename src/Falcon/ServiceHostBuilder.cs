using Microsoft.AspNetCore.Hosting;

namespace Falcon
{
    public class ServiceHostBuilder
    {
        public ServiceHost Build()
        {
            return new ServiceHost(
                new WebHostBuilder()
                    .UseKestrel()
                    .UseUrls("http://+:11800/")
                    .UseStartup<ServiceHost.Startup>()
                    .Build());
        }
    }
}
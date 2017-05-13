using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Falcon.Tests
{
    public class ServiceHostFacts
    {
        [Fact]
        public async Task Provides_Service_Information_Over_Http_On_Port_11800()
        {
            using (var host = new ServiceHostBuilder().Build())
            using (var client = new HttpClient())
            {
                // ReSharper disable once AccessToDisposedClosure
                await Task.Run(() => host.Start());
                HttpResponseMessage response = await client.GetAsync("http://localhost:11800/");
                Assert.NotNull(response);
            }
        }
    }
}



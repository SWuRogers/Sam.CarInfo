using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace Sam.CarInfo.Test
{
    public class ControllerTestBase
    {
        protected HttpClient GetClient()
        {
            var builder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(new ConfigurationBuilder().AddJsonFile("appsettings.json").Build())
                .UseStartup<Startup>()
                .UseEnvironment("Testing");

            var server = new TestServer(builder);
            var client = server.CreateClient();

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }

    public class CarInfoTest: ControllerTestBase
    {
        private readonly HttpClient _client;

        public CarInfoTest()
        {
            _client = base.GetClient();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task Monkey(int para)
        {
            var response = await this._client.GetAsync($"/car/{para}");
            response.EnsureSuccessStatusCode();
            Console.WriteLine(response.StatusCode);
        }


    }
}

using System;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Lab1;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace XUnitTest1
{
    public class UnitTests
    {
        [Fact]
        public async Task IndexGetOKTest()
        {
            var hostBuilder = new WebHostBuilder().UseStartup<Startup>();

            using (var server = new TestServer(hostBuilder))
            {
                var response = await server.CreateRequest("/")
                     .SendAsync("GET");

                Assert.Equal(System.Net.HttpStatusCode.OK.ToString(), response.StatusCode.ToString());
            }
        }

        [Fact]
        public async Task StaticFileOKTest()
        {
            var hostBuilder = new WebHostBuilder().UseStartup<Startup>();

            using (var server = new TestServer(hostBuilder))
            {
                var response = await server.CreateRequest("/html/index.html")
                     .SendAsync("GET");

                Assert.Equal(System.Net.HttpStatusCode.OK.ToString(), response.StatusCode.ToString());
            }
        }
    }
}

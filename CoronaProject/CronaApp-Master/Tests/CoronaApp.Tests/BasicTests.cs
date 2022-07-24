using CoronaApp.Api;
using CoronaApp.Dal;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoronaApp.Tests
{
    public class BasicTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public BasicTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")] //route is not defined
        [InlineData("/api/Location")]
        [InlineData("/api/Locationj")]

        public async Task GetHttpRequest(string url)
        {
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<ILocationDal, LocationMock>();
                });
            })
      .CreateClient();
            //var client = _factory.CreateClient();
            var response = await client.GetAsync(url);
            //response.EnsureSuccessStatusCode();
            Assert.Equal("text/plain",
                response.Content.Headers.ContentType.ToString());
        }
    }
}

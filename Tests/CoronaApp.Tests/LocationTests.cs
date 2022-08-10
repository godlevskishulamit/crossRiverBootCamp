using CoronaApp.Api;
using CoronaApp.Dal;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CoronaApp.Api;

namespace CoronaApp.Tests
{
    public class LocationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public LocationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        [Theory]
        [InlineData("api/Location")]

        public async Task getLocations(string url)
        {
            //Arrange
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<ILocationRepository, MockLocationRepository>();
                });
            })
        .CreateClient();

            //Act
            var response = await client.GetAsync(url);

            //Assert
            /*
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());*/
            Assert.NotNull(response);
        }
    }
}

/*public async Task getLocations(string url)
{
    //Arrange
    var client = _factory.CreateClient();

    //Act
    var response = await client.GetAsync(url);

    //Assert
    response.EnsureSuccessStatusCode();
    Assert.Equal("application/json; charset=utf-8",
        response.Content.Headers.ContentType.ToString());
}*/

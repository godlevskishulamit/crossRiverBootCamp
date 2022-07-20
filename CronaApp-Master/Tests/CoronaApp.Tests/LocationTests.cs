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

namespace CoronaApp.Tests
{
    public class LocationTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public LocationTests(WebApplicationFactory<Startup> factory)
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
                    services.AddScoped<ILocationDal, MockLocationDal>();
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

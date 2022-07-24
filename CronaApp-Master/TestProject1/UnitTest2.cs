using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Dal;
using CoronaApp.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace CoronaApp.Tests
{
    public class UnitTest2 : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public UnitTest2(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        [Theory]
        [InlineData("https://localhost:44381/api/Patient/")]
        public async Task getHttpRequest(string url)
        {
            //arrange
            var Client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<IDalPatient, MockDataPatient>();
                });
            })
                .CreateClient();
            //act
            var response = await Client.GetAsync(url);
            //assert
            response.EnsureSuccessStatusCode();
            Assert.NotEqual(response.Content,null);
        }
    }
}

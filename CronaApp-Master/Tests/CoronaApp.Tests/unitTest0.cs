using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoronaApp.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CoronaApp.Tests
{
    public class unitTest0 : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public unitTest0(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Theory]
        [InlineData("https://localhost:44381/api/Patient/")]
        public async Task getHttpRequest(string url)
        {
            //arrange
            var Client = _factory.CreateClient();
            //act
            var response = await Client.GetAsync(url);
            //assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}


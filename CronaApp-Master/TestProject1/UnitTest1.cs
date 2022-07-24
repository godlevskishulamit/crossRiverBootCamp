using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace CoronaApp.Tests
{
    public class TestProject1 : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public TestProject1(WebApplicationFactory<Program> factory)
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


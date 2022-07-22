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
    public class LocationTest : IClassFixture<WebApplicationFactory<Program>>
    {

        private WebApplicationFactory<Program> _coronaApp;
        public LocationTest(WebApplicationFactory<Program> coronaApp)
        {
            _coronaApp = coronaApp;
        }

        [Theory]
        [InlineData("api/Location/212625917")]
        public async Task getLocationsByPatientId(string url)
        {
            //Arrange:
            var client = _coronaApp.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<ILocationDal, MockLocationDal>();
                });
            })
      .CreateClient();
            /*var client = _coronaApp.WithWebHostBuilder(builder => {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<ILocationDal, MockLocationDal>();
                });
            }).CreateClient();
*/
            //Act:
            var res = await client.GetAsync(url);

            //Assert:
            res.EnsureSuccessStatusCode();
            Assert.NotEqual(res.Content, null);
        }

        /*    [Fact]*/

        /*    public async Task locations()
            {

            }*/
    }
}

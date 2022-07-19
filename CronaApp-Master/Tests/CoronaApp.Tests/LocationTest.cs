
using CoronaApp.Dal.Models;
using Microsoft.AspNetCore.Mvc.Testing;

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using Xunit;

namespace CoronaApp.Tests
{

    public class LocationTest : IClassFixture<WebApplicationFactory<CoronaApp.Api.Startup>>
    {
        private WebApplicationFactory<CoronaApp.Api.Startup> _factory;
        public LocationTest(WebApplicationFactory<CoronaApp.Api.Startup> factory)//,ILocationRepository location, ILocationDal locationDal, CoronaDBContext dbcontext, LocationController locationController)
        {
            _factory = factory;
        }
        [Theory]
        [InlineData("api/Location/208624403")]
        public async void GetLocationsByPatientId_WithId208624403_ReturnsOneLocation(string url)
        {
            //arrange
            var client = _factory.CreateClient();
            var Good = new List<Location>();
            Good.Add(new Location
            {
                Id = 15,
                StartDate = new System.DateTime(2022, 07, 11, 00, 00, 00),
                EndDate = new System.DateTime(2022, 07, 13, 00, 00, 00),
                City = "Ashdod",
                Adress = "Shoshanim",
                PatientId = "208624403"

            });
            //act
            System.Net.Http.HttpResponseMessage Test = await client.GetAsync(url);
            List<Location> data = await Test.Content.ReadAsAsync<List<Location>>(new[] { new JsonMediaTypeFormatter() });
            //assert           
            Assert.Equal(Good[0].Id, data[0].Id);// Test.Content.ReadAsStreamAsync);

            Assert.Equal(Good[0].StartDate, data[0].StartDate);
            Assert.Equal(Good[0].EndDate, data[0].EndDate); ;
            Assert.Equal(Good[0].City, data[0].City);
            Assert.Equal(Good[0].Adress, data[0].Adress);
            Assert.Equal(Good[0].PatientId, data[0].PatientId);
        }
        [Theory]
        [InlineData("api/Location/1")]
        public async void GetLocationsByPatientId_WithIdNotExist_ReturnsError(string url)
        {
            //arrange
            var client = _factory.CreateClient();
            //act
            System.Net.Http.HttpResponseMessage Test = await client.GetAsync(url);
            //assert
            Assert.Equal(Test.StatusCode, System.Net.HttpStatusCode.InternalServerError);
        }


    }
}

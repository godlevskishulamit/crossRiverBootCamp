using CoronaApp.Api;
using CoronaApp.Dal.Classes;
using CoronaApp.Dal.Interfaces;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CoronaApp.Tests;
public class TestCoronaApp : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> factory;
    public TestCoronaApp(WebApplicationFactory<Program> factory)
    {
        this.factory = factory;
    }

    [Theory]
    [InlineData("https://localhost:44381/api/Location/GetLocationsPerPatient/123456789")]
    [InlineData("https://localhost:44381/api/Location/GetLocationsPerPatient/987654321")]
    public async Task GetLocationsPerPatient(string url)
    {
        //Arrange
        var client = factory.WithWebHostBuilder(builder =>
        builder.ConfigureTestServices(services =>
        {
            services.AddScoped<ILocationDAL, LocationDalMock>();
        })).CreateClient();

        //Act
        var response = await client.GetAsync(url);

        //Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
    }

    [Theory]
    [InlineData("https://localhost:44381/api/Location/GetLocationsPerPatient/741147741")]
    [InlineData("https://localhost:44381/api/Location/GetLocationsPerPatient/1")]
    public async Task GetLocationsPerPatientEqualNull(string url)
    {
        //Arrange
        var client = factory.CreateClient();

        //Act
        var response = await client.GetAsync(url);

        //Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(null, response.Content.Headers.ContentType);
    }
}

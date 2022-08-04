using CoronaApp.Services;
using CoronaApp.Services.Mocks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace CoronaApp.Tests;
public class ApiTests
{
    [Theory]
    [InlineData("/api/Location")]
    [InlineData("/api/Location/patientId?patientId=1")]
    [InlineData("/api/Location/city?city=1")]
    [InlineData("/api/Patient/id?id=1")]
    public async void GetHttp(string url)
    {
        var factory = new WebApplicationFactory<Program>();
        var client = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureTestServices(services =>
            {
                services.AddScoped<ILocationRepository, LocationMock>();
                services.AddScoped<IPatientRepository, PatientMock>();
            });
        }).CreateClient();

        var response = await client.GetAsync(url);
        var result = await response.Content.ReadAsStringAsync();

        Assert.Equal("", result);
    }
}

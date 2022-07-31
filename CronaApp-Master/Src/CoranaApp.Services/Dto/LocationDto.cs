using System;
namespace CoronaApp.Services.Dto
{
    public record LocationDto(DateTime StartDate, DateTime EndDate, string Address, string City, string patientId);
}


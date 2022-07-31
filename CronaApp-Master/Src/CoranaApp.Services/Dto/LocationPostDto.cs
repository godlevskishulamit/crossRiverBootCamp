using System;
namespace CoronaApp.Services.Dto
{
    public record LocationPostDto(DateTime StartDate, DateTime EndDate, string Address, string City);
}

